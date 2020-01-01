Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
    <HttpGet>
    Public Function getCost(origin As String, destination As String, weight As String) As JsonResult
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
        Return Json(cost * Math.Pow(1.25, decWeight \ 5), JsonRequestBehavior.AllowGet)
    End Function
End Class
