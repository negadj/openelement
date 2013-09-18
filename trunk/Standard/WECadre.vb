Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Elements
Imports openElement.WebElement.StylesManager

Imports WebElement.My.Resources.text

Namespace Elements.Standard

    ''' <summary>
    ''' this element is just a graphic element. 
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable> _
    Public Class WECadre
        Inherits ElementBase

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WECadre", page, parentID, templateName)
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0191
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupStandard"
            info.ToolBoxIco = My.Resources.WECadre
            info.ToolBoxDescription = LocalizableOpen._0192
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("Top", LocalizableOpen._0193, LocalizableOpen._0194))
            configStylesZones.Add(New ConfigStylesZone("Content", LocalizableOpen._0195, LocalizableOpen._0196))
            configStylesZones.Add(New ConfigStylesZone("Bottom", LocalizableOpen._0197, LocalizableOpen._0198))

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Top"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Content"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Bottom"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

    End Class

End Namespace

