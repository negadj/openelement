Imports openElement.WebElement.Elements
Imports openElement.WebElement

Namespace Elements.Standard

    <Serializable()> _
Public Class WEHrVertival
        Inherits ElementBase

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEHrVertival", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.Height
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0238
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupStandard"
            info.ToolBoxIco = My.Resources.WEHrVertival
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0239
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim ConfigStylesZones As New List(Of StylesManager.ConfigStylesZone)
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Deco1", My.Resources.text.LocalizableOpen._0140, My.Resources.text.LocalizableOpen._0141)) '"Décoration 1", "Zone de décoration 1"
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Deco2", My.Resources.text.LocalizableOpen._0142, My.Resources.text.LocalizableOpen._0143)) '"Décoration 2", "Zone de décoration 2"
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Deco3", My.Resources.text.LocalizableOpen._0144, My.Resources.text.LocalizableOpen._0144)) '"Décoration 3", "Zone de décoration 3"

            MyBase.OnOpen(ConfigStylesZones)
        End Sub

#End Region

#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Deco1"))
            writer.WriteAttribute("style", "position:absolute")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Deco2"))
            writer.WriteAttribute("style", "position:absolute")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Deco3"))
            writer.WriteAttribute("style", "position:absolute")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            MyBase.RenderEndTag(writer)

        End Sub

#End Region

    End Class
End Namespace