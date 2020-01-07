Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function
    Function quoteResults() As ActionResult
        Dim offers As New List(Of offerItem)
        offers = TempData("offers")
        Return View(offers)
    End Function
    <HttpPost>
    Function Index(<Bind(Include:="destination, origin, weight")> ByVal sInfo As shipmentInfo) As ActionResult
        'ViewData("rvdValues") = $"received: origin={sInfo.origin}, destination={sInfo.destination}, weight={sInfo.weight}"
        Dim cost As Decimal = getCost(sInfo.origin, sInfo.destination, sInfo.weight)
        Dim offerList As New List(Of offerItem)
        Dim item1 As New offerItem With {
        .supplierIcon = "ups.png",
        .supplierService = "UPS Standard",
        .collectionIcon = "truck.png",
        .collectionDescription = "Collection tomorrow",
        .coverText = "30 eur cover included",
        .coverIcon = "protection.png",
        .printerIcon = "printer.png",
        .printerText = "Printer Needed",
        .deliverytext = "Delivery on Monday 15th",
        .deliveryIcon = "truck.png",
        .price = cost,
        .economyClass = "Economy Delivery"
        }
        offerList.Add(item1)
        Dim item2 As New offerItem With {
        .supplierIcon = "fedex.png",
        .supplierService = "FEDEX Economy",
        .collectionIcon = "truck.png",
        .collectionDescription = "Collection tomorrow",
        .coverText = "30 eur cover included",
        .coverIcon = "protection.png",
        .printerIcon = "printer.png",
        .printerText = "Printer Needed",
        .deliverytext = "Delivery on Monday 15th",
        .deliveryIcon = "truck.png",
        .price = cost * 1.02,
        .economyClass = "Economy Delivery"
        }
        offerList.Add(item2)
        Dim item3 As New offerItem With {
        .supplierIcon = "dhl.png",
        .supplierService = "DHL Standard",
        .collectionIcon = "truck.png",
        .collectionDescription = "Collection tomorrow",
        .coverText = "40 eur cover included",
        .coverIcon = "protection.png",
        .printerIcon = "printer.png",
        .printerText = "Printer Needed",
        .deliverytext = "Delivery on Monday 15th",
        .deliveryIcon = "truck.png",
        .price = cost * 1.05,
        .economyClass = "Economy Delivery"
        }
        offerList.Add(item3)

        Dim item11 As New offerItem With {
        .supplierIcon = "ups.png",
        .supplierService = "UPS Express",
        .collectionIcon = "truck.png",
        .collectionDescription = "Collection tomorrow",
        .coverText = "30 eur cover included",
        .coverIcon = "protection.png",
        .printerIcon = "printer.png",
        .printerText = "Printer Needed",
        .deliverytext = "Delivery on Monday 13th",
        .deliveryIcon = "truck.png",
        .price = cost * 1.2,
        .economyClass = "Express Delivery"
        }
        offerList.Add(item11)
        Dim item12 As New offerItem With {
        .supplierIcon = "fedex.png",
        .supplierService = "FEDEX Express",
        .collectionIcon = "truck.png",
        .collectionDescription = "Collection tomorrow",
        .coverText = "30 eur cover included",
        .coverIcon = "protection.png",
        .printerIcon = "printer.png",
        .printerText = "Printer Needed",
        .deliverytext = "Delivery on Monday 13th",
        .deliveryIcon = "truck.png",
        .price = cost * 1.23,
        .economyClass = "Express Delivery"
        }
        offerList.Add(item12)
        Dim item13 As New offerItem With {
        .supplierIcon = "dhl.png",
        .supplierService = "DHL Express",
        .collectionIcon = "truck.png",
        .collectionDescription = "Collection tomorrow",
        .coverText = "40 eur cover included",
        .coverIcon = "protection.png",
        .printerIcon = "printer.png",
        .printerText = "Printer Needed",
        .deliverytext = "Delivery on Monday 13th",
        .deliveryIcon = "truck.png",
        .price = cost * 1.25,
        .economyClass = "Express Delivery"
        }
        offerList.Add(item13)

        Dim item21 As New offerItem With {
        .supplierIcon = "ups.png",
        .supplierService = "UPS Value",
        .collectionIcon = "truck.png",
        .collectionDescription = "Collection tomorrow",
        .coverText = "30 eur cover included",
        .coverIcon = "protection.png",
        .printerIcon = "printer.png",
        .printerText = "Printer Needed",
        .deliverytext = "Delivery on Monday 13th",
        .deliveryIcon = "truck.png",
        .price = cost * 1.8,
        .economyClass = "Priority Delivery"
        }
        offerList.Add(item21)
        Dim item22 As New offerItem With {
        .supplierIcon = "fedex.png",
        .supplierService = "FEDEX Priority",
        .collectionIcon = "truck.png",
        .collectionDescription = "Collection tomorrow",
        .coverText = "30 eur cover included",
        .coverIcon = "protection.png",
        .printerIcon = "printer.png",
        .printerText = "Printer Needed",
        .deliverytext = "Delivery on Monday 13th",
        .deliveryIcon = "truck.png",
        .price = cost * 1.9,
        .economyClass = "Priority Delivery"
        }
        offerList.Add(item22)
        Dim item23 As New offerItem With {
        .supplierIcon = "dhl.png",
        .supplierService = "DHL Express",
        .collectionIcon = "truck.png",
        .collectionDescription = "Collection tomorrow",
        .coverText = "40 eur cover included",
        .coverIcon = "protection.png",
        .printerIcon = "printer.png",
        .printerText = "Printer Needed",
        .deliverytext = "Delivery on Monday 13th",
        .deliveryIcon = "truck.png",
        .price = cost * 2,
        .economyClass = "Priority Delivery"
        }
        offerList.Add(item23)

        TempData("offers") = offerList
        Return RedirectToAction("quoteResults")
    End Function
    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
    Function SignUp() As ActionResult
        ViewData("Message") = "Your contact page."
        Return View()
    End Function
    <HttpGet>
    Public Function getCost(origin As String, destination As String, weight As String) As Decimal
        Dim fileContent As String
        Dim path As String = Server.MapPath("~/App_Data/costs.txt")
        Using sr As New System.IO.StreamReader(path)
            fileContent = sr.ReadToEnd()
        End Using
        Dim fileContentArray As String() = fileContent.Split(Environment.NewLine)
        Dim s1 As String = Join({origin, destination}, "|")
        Dim s2 As String = Join({destination, origin}, "|")
        Dim i As Integer = 0
        Do Until Left(fileContentArray(i).Replace(vbLf, String.Empty), Len(s1)) = s1 Or Left(fileContentArray(i).Replace(vbLf, String.Empty), Len(s1)) = s2 Or i = fileContentArray.Length - 1
            i += 1
        Loop
        Dim cost As Integer = Integer.Parse(fileContentArray(i).Split("|")(2))
        Dim decWeight As Decimal = Decimal.Parse(weight)
        Return cost * Math.Pow(1.25, decWeight \ 5)
    End Function

    <HttpGet>
    Public Function getCostJ(origin As String, destination As String, weight As String) As JsonResult
        Dim cost As Decimal = getCost(origin, destination, weight)
        Return Json(cost, JsonRequestBehavior.AllowGet)
    End Function

End Class
