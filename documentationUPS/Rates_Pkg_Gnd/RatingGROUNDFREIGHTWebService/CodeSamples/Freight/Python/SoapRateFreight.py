import xml.etree.ElementTree as ET
from zeep import Client, Settings
from zeep.exceptions import Fault, TransportError, XMLSyntaxError

# Set Connection
settings = Settings(strict=False, xml_huge_tree=True)
client = Client('SCHEMA-WSDLs/FreightRate.wsdl', settings=settings)

# Set SOAP headers
headers = {

    'UPSSecurity': {
        'UsernameToken': {
            'Username': 'Your Username',
            'Password': 'Your Password'
        },

        'ServiceAccessToken': {
            'AccessLicenseNumber': 'You AccessLicense Number'
        }

    }
}

# Create request dictionary
requestDictionary = {

    "RequestOption": "1",
    "TransactionReference": {
        "CustomerContext": "Your Customer Context"
    }
}

# Create Rate Freight ShipFrom dictionary
ShipFromDictionary = {

    "Address": {
        "AddressLine": "Street Name",
        "City": "City Name",
        "CountryCode": "Country Code",
        "PostalCode": "Postal Code",
        "StateProvinceCode": "State or Province Code"
    },
    "Name": "",
}

# Create Rate Freight ShipTo dictionary
ShipToDictionary = {

    "Address": {
        "AddressLine": "Street Name",
        "City": "City Name",
        "CountryCode": "Country Code",
        "PostalCode": "Postal Code",
        "StateProvinceCode": "State or Province Code"
    },
    "Name": ""

}

# Create Rate Freight PaymentInformation Dictionary
paymentInformationDictionary = {

    "Payer": {
        "Address": {
            "AddressLine": "Street Name",
            "City": "City Name",
            "CountryCode": "Country Code",
            "PostalCode": "Postal Code",
            "StateProvinceCode": "State or Province Code",
        },
        "AttentionName": "",
        "Name": "",
        "ShipperNumber": "Shipper Number"
    },
    "ShipmentBillingOption": {
        "Code": "10",
        "Description": "Prepaid"
    }

}

# Create Rate Freight Service Dictionary
serviceDictionary = {

    "Code": "308",
    "Description": "UPS Freight LTL"

}

# Create Rate Freight HandlingUnitOne Dictionary
handlingUnitOneDictionary = {

    "Quantity": "1",
    "Type": {
        "Code": "SKD",
        "Description": "SKID"
    }
}

# Create Rate Freight Commodity Dictionary
commodityDictionary = {

    "CommodityID": "01",
    "CommodityValue": {
        "CurrencyCode": "USD",
        "MonetaryValue": "100.00"
    },
    "Description": "Commodity Description",
    "Dimensions": {
        "Height": "35",
        "Length": "12",
        "UnitOfMeasurement": {
            "Code": "IN",
            "Description": "Inches"
        },
        "Width": "52"
    },
    "FreightClass": "60",
    "NumberOfPieces": "20",
    "PackagingType": {
        "Code": "PLT",
        "Description": ""
    },
    "Weight": {
        "UnitOfMeasurement": {
            "Code": "LBS",
            "Description": ""
        },
        "Value": "200"
    }

}

# Try operation
try:
    response = client.service.ProcessFreightRate(_soapheaders=headers, Request=requestDictionary,
                                                 ShipFrom=ShipFromDictionary, ShipTo=ShipToDictionary,
                                                 PaymentInformation=paymentInformationDictionary,
                                                 Service=serviceDictionary, HandlingUnitOne=handlingUnitOneDictionary,
                                                 Commodity=commodityDictionary)
    print(response)

except Fault as error:
    print(ET.tostring(error.detail))
