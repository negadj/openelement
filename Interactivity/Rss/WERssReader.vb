'Imports System.ComponentModel
'Imports openElement.WebElement.Elements
'Imports openElement.WebElement
'Imports openElement
'Imports openElement.WebElement.Editors
'Imports openElement.WebElement.Editors.Control.CtlEditListOf
'Imports openElement.WebElement.LinksManager





'Namespace Elements.Interactivity
'#Region "WE Class"
'    'Notre Element RssReader
'    <Serializable()> _
'Public Class WERssReader
'        Inherits ElementBase


'#Region "Constructor"

'        Public Sub New(ByVal Page As Page, ByVal ParentID As String, ByVal TemplateName As String)
'            MyBase.New(EnuElementType.PageEdit, "WERssReader", Page, ParentID, TemplateName)
'            MyBase.TypeResize = EnuTypeResize.Both 'Peut être redimenssioné en hauteur et en taille
'        End Sub

'#End Region

'#Region "OnOpen"

'        Protected Overrides Sub OnOpen()
'            MyBase.ElementInfo.ToolBoxCaption = My.Resources.text.LocalizableOpen._0358 'Flux Rss
'            MyBase.ElementInfo.VersionMajor = 1
'            MyBase.ElementInfo.VersionMinor = 0
'            MyBase.ElementInfo.GroupName = "NBGroupInteractivity" ' Nom du groupe: Interactivité
'            MyBase.ElementInfo.ToolBoxIco = My.Resources.WERss ' Icône
'            MyBase.ElementInfo.ToolBoxDescription = My.Resources.text.LocalizableOpen._0335 'Ajout Flux Rss

'            Dim ConfigStylesZones As New List(Of StylesManager.ConfigStylesZone) 'Création de la zonne de style Icon
'            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("MainZone", My.Resources.text.LocalizableFormAndConverter._0182, My.Resources.text.LocalizableFormAndConverter._0182))' Zone Icône
'            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("TitleZone", My.Resources.text.LocalizableFormAndConverter._0182, My.Resources.text.LocalizableFormAndConverter._0182))
'            MyBase.OnOpen(ConfigStylesZones)
'            'MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "", "")

'        End Sub

'#End Region

'#Region "Render"

'        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)
'            MyBase.RenderBeginTag(writer)
'            writer.WriteBeginTag("div")
'            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("MainZone"))
'            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
'            writer.WriteBeginTag("div")
'            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("TitleZone"))
'            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
'            writer.WriteEndTag("div")
'            writer.WriteEndTag("div")
'            MyBase.RenderEndTag(writer)

'        End Sub

'#End Region


'    End Class
'#End Region
'End Namespace