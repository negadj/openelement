Imports openElement.WebElement.Elements
Imports openElement.WebElement

Namespace Elements.Other

    <Serializable()> _
Public Class WEW3C
        Inherits ElementBase

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEW3C", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0232
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupOther"
            info.ToolBoxIco = My.Resources.WEW3C
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0011
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim ConfigStylesZones As New List(Of StylesManager.ConfigStylesZone)

            MyBase.OnOpen(ConfigStylesZones)
        End Sub

#End Region

#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)

            writer.WriteBeginTag("a")
            writer.WriteAttribute("href", "http://validator.w3.org/check?uri=referer&amp;doctype=XHTML+1.0+Transitional")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

            writer.WriteBeginTag("img")
            writer.WriteAttribute("src", MyBase.ConvertToRelativeLink("WEFiles/Image/WEW3C.png"))
            writer.WriteAttribute("alt", "Valid XHTML 1.0 Transitional")
            writer.WriteAttribute("height", "31")
            writer.WriteAttribute("width", "88")
            writer.WriteAttribute("style", "border-style:hidden")
            writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)

            writer.WriteEndTag("a")


            MyBase.RenderEndTag(writer)

        End Sub

#End Region


    End Class
End Namespace