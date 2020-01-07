/* 
 ** 
 ** Filename: JAXBAVClient.java
 ** Authors: United Parcel Service of America
 ** 
 ** The use, disclosure, reproduction, modification, transfer, or transmittal 
 ** of this work for any purpose in any form or by any means without the 
 ** written permission of United Parcel Service is strictly prohibited. 
 ** 
 ** Confidential, Unpublished Property of United Parcel Service. 
 ** Use and Distribution Limited Solely to Authorized Personnel. 
 ** 
 ** Copyright 2009 United Parcel Service of America, Inc.  All Rights Reserved. 
 ** 
 */ 
package com.ups.xolt.codesamples;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileWriter;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.StringWriter;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLConnection;
import java.util.List;
import java.util.Properties;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.Marshaller;
import javax.xml.bind.Unmarshaller;

import com.ups.xolt.codesamples.accessrequest.jaxb.AccessRequest;
import com.ups.xolt.codesamples.request.jaxb.AddressType;
import com.ups.xolt.codesamples.request.jaxb.AddressValidationRequest;
import com.ups.xolt.codesamples.request.jaxb.RequestType;
import com.ups.xolt.codesamples.response.jaxb.AddressValidationResponse;
import com.ups.xolt.codesamples.response.jaxb.AddressValidationResultType;


public class JAXBAVClient {
	
	private static final String LICENSE_NUMBER = "accesskey";
	private static final String USER_NAME = "username";
	private static final String PASSWORD = "password";
	private static final String ENDPOINT_URL="url";
	private static final String OUT_FILE_LOCATION = "out_file_location";
	static Properties props = null;
 
	static{
    	try{
        	props = new Properties();
        	props.load(new FileInputStream("./build.properties"));

    	}catch (Exception e) {
			e.printStackTrace();
		}    	
    }
    
    public static void main( String[] args ) {    
    	
    	String statusCode = null;
		String description = null;
		StringWriter strWriter = null;
        try {	    
        	
        	//Create JAXBContext and marshaller for AccessRequest object        			
        	JAXBContext accessRequestJAXBC = JAXBContext.newInstance(AccessRequest.class.getPackage().getName() );	            
			Marshaller accessRequestMarshaller = accessRequestJAXBC.createMarshaller();
			com.ups.xolt.codesamples.accessrequest.jaxb.ObjectFactory accessRequestObjectFactory = new com.ups.xolt.codesamples.accessrequest.jaxb.ObjectFactory();
			AccessRequest  accessRequest = accessRequestObjectFactory.createAccessRequest();
			populateAccessRequest(accessRequest);
			 
			//Create JAXBContext and marshaller for AddressValidationRequest object
			JAXBContext avRequestJAXBC = JAXBContext.newInstance(AddressValidationRequest.class.getPackage().getName() );	            
			Marshaller avRequestMarshaller = avRequestJAXBC.createMarshaller();
			com.ups.xolt.codesamples.request.jaxb.ObjectFactory requestObjectFactory = new com.ups.xolt.codesamples.request.jaxb.ObjectFactory();
			AddressValidationRequest avRequest = requestObjectFactory.createAddressValidationRequest();
			populateAVRequest(avRequest);			
			//Get String out of access request and AddressValidationRequest objects.
			strWriter = new StringWriter();       		       
			accessRequestMarshaller.marshal(accessRequest, strWriter);
			avRequestMarshaller.marshal(avRequest, strWriter);
			strWriter.flush();
			strWriter.close();
			System.out.println("Request: " + strWriter.getBuffer().toString());
			String strResults =contactService(strWriter.getBuffer().toString());
			
			//Parse response object.
			JAXBContext avResponseJAXBC = JAXBContext.newInstance(AddressValidationResponse.class.getPackage().getName());
			Unmarshaller avResponseUnmarhsaller = avResponseJAXBC.createUnmarshaller();
			ByteArrayInputStream input = new ByteArrayInputStream(strResults.getBytes());
			Object objResponse = avResponseUnmarhsaller.unmarshal(input);
			AddressValidationResponse	avResponse = (AddressValidationResponse)objResponse;
			List<AddressValidationResultType> avList  = avResponse.getAddressValidationResult();
			
			if(avList != null && avList.size()> 0){
				System.out.println("Address Validation Result");
				int cnt = 0;
				while(cnt < avList.size()){
					AddressValidationResultType avResult = avList.get(cnt);
					System.out.println("Rank: " + avResult.getRank());
					System.out.println("Quality: " + avResult.getQuality());
					System.out.println("City: " + avResult.getAddress().getCity());
					System.out.println("StateProvinceCode: " + avResult.getAddress().getStateProvinceCode());
					System.out.println("PostalCodeLowEnd: " + avResult.getPostalCodeLowEnd());
					System.out.println("PostalCodeHighEnd: " + avResult.getPostalCodeHighEnd());
					cnt++;
				}
			}
			
			updateResultsToFile(strResults);		   
        } catch (Exception e) { 
			updateResultsToFile(e.toString());
			e.printStackTrace();
		} finally{
			try{
				if(strWriter != null){
					strWriter.close();
					strWriter = null;
				}
			}catch (Exception e) {
				updateResultsToFile(e.toString());
				e.printStackTrace();
			}
		}
    }    
    
	private static String contactService(String xmlInputString) throws Exception{		
		String outputStr = null;
		OutputStream outputStream = null;
		try {
			URL url = new URL(props.getProperty(ENDPOINT_URL));
			
			HttpURLConnection connection = (HttpURLConnection) url.openConnection();
			System.out.println("Client established connection with " + url.toString());
			// Setup HTTP POST parameters
			connection.setDoOutput(true);
			connection.setDoInput(true);
			connection.setUseCaches(false);
			
			outputStream = connection.getOutputStream();		
			outputStream.write(xmlInputString.getBytes());
			outputStream.flush();
			outputStream.close();
			System.out.println("Http status = " + connection.getResponseCode() + " " + connection.getResponseMessage());
			
			outputStr = readURLConnection(connection);			
		} catch (Exception e) {
			System.out.println("Error sending data to server");
			throw e;
		} finally {						
			if(outputStream != null){
				outputStream.close();
				outputStream = null;
			}
		}		
		return outputStr;
	}
	
	/**
	 * This method read all of the data from a URL connection to a String
	 */

	public static String readURLConnection(URLConnection uc) throws Exception {
		StringBuffer buffer = new StringBuffer();
		BufferedReader reader = null;
		try {
			reader = new BufferedReader(new InputStreamReader(uc.getInputStream()));
			int letter = 0;			
			while ((letter = reader.read()) != -1){
				buffer.append((char) letter);
			}
			reader.close();
		} catch (Exception e) {
			System.out.println("Could not read from URL: " + e.toString());
			throw e;
		} finally {
			if(reader != null){
				reader.close();
				reader = null;
			}
		}
		return buffer.toString();
	}

    /**
     * Populates the access request object.
     * @param accessRequest
     */
    private static void populateAccessRequest(AccessRequest accessRequest){
    	accessRequest.setAccessLicenseNumber(props.getProperty(LICENSE_NUMBER));
    	accessRequest.setUserId(props.getProperty(USER_NAME));
    	accessRequest.setPassword(props.getProperty(PASSWORD));
    }
   
    /**
     * Populate AddressValidationRequest object
     * @param avRequest
     */
    private static void populateAVRequest(AddressValidationRequest avRequest){   	
    	RequestType request = new RequestType(); 
     	request.setRequestAction("AV");
     	avRequest.setRequest(request);
    	AddressType address = new AddressType();
    	address.setCity("ALPHARETTA");
    	address.setPostalCode("300053778");
    	avRequest.setAddress(address);
     	
    }
    
    /**
     * This method updates the XOLTResult.xml file with the received status and description
     * @param statusCode
     * @param description
     */
    
    private static void updateResultsToFile(String response){
    	BufferedWriter bw = null;
    	try{    		
    		
    		File outFile = new File(props.getProperty(OUT_FILE_LOCATION));
    		System.out.println("Output file deletion status: " + outFile.delete());
    		outFile.createNewFile();
    		System.out.println("Output file location: " + outFile.getCanonicalPath());
    		bw = new BufferedWriter(new FileWriter(outFile));
    		StringBuffer strBuf = new StringBuffer();
    		strBuf.append(response);
    		bw.write(strBuf.toString());
    		bw.close();    		    		
    	}catch (Exception e) {
			e.printStackTrace();
		}finally{
			try{
				if (bw != null){
					bw.close();
					bw = null;
				}
			}catch (Exception e) {
				e.printStackTrace();
			}			
		}		
    }
}