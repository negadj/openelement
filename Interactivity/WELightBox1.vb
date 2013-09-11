Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.DataType
Imports openElement.WebElement.Editors.Control.CtlEditListOf
Imports WebElement.Elements.Interactivity.Editors.Form
Imports openElement.WebElement.ElementWECommon.Interactivity.Forms

Namespace Elements.Interactivity

    <Serializable()> _
    Public Class WELightBox1
        Inherits ElementBase

#Region "Properties"

        ''' <summary>
        ''' main config
        ''' </summary>
        ''' <remarks></remarks>
        <Common.Attributes.ContainsLinks()> _
        Private _ConfigLightBox1 As List(Of FrmLightBox1.ImgLightBoxConfig)

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Editor(GetType(openElement.WebElement.Editors.UITypeEditListOf), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property ConfigLightBox1() As List(Of FrmLightBox1.ImgLightBoxConfig)
            Get
                If _ConfigLightBox1 Is Nothing Then _ConfigLightBox1 = New List(Of FrmLightBox1.ImgLightBoxConfig)
                Return _ConfigLightBox1
            End Get
            Set(ByVal value As List(Of FrmLightBox1.ImgLightBoxConfig))
                _ConfigLightBox1 = value
            End Set
        End Property


#End Region

#Region "Builder required function"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.HiddenEdit, "WELightBox1", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub


        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0204
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupInteractivity"
            info.ToolBoxIco = My.Resources.WEGallery1
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0205
            info.AutoOpenProperty = "ConfigLightBox1"
            info.SortPropertyList.Add(New SortProperty("ConfigLightBox1", "Tools.png", My.Resources.text.LocalizableOpen._0030))
            Return info

        End Function

        Protected Overrides Sub OnOpen()


            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)

            configStylesZones.Add(New StylesManager.ConfigStylesZone("ContentLightBox", My.Resources.text.LocalizableOpen._0207, My.Resources.text.LocalizableOpen._0331))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("LeaveLightBox", My.Resources.text.LocalizableOpen._0208, My.Resources.text.LocalizableOpen._0330))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("GoRightLightBox", My.Resources.text.LocalizableOpen._0209, My.Resources.text.LocalizableOpen._0209))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("GoLeftLightBox", My.Resources.text.LocalizableOpen._0210, My.Resources.text.LocalizableOpen._0210))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("TitleLightBox", My.Resources.text.LocalizableOpen._0211, My.Resources.text.LocalizableOpen._0211))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("OverviewLightBox", My.Resources.text.LocalizableOpen._0212, My.Resources.text.LocalizableOpen._0212))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("LinkLightBox", My.Resources.text.LocalizableOpen._0332, My.Resources.text.LocalizableOpen._0333))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("MaskLightBox", My.Resources.text.LocalizableOpen._0328, My.Resources.text.LocalizableOpen._0329))

            MyBase.OnOpen(configStylesZones)

        End Sub

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(Common.EnuScriptType.Css, "ElementsLibrary\Common\Css\WELightBox1.css", "WEFiles/Css/WELightBox1.css")
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WELightBox1.js", "WEFiles/Client/WELightBox1.js")
            MyBase.OnInitExternalFiles()
        End Sub

        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As AddButton, ByVal selectedNodeTag As NodeTag) As List(Of Object)

            Dim newObs As New List(Of Object)
            If addButton.Name = "AddImage" Then
                Dim elementsFilter As New String("WEImage")
                Dim wizzardLightBox As New FrmLightBox1(Me, elementsFilter)
                If wizzardLightBox.ShowDialog = Windows.Forms.DialogResult.OK Then
                    newObs.Add(wizzardLightBox.ImgLightBox)
                End If

            End If
            Return newObs
        End Function

        Protected Overrides Function OnFrmEditListOfGetFormConfig() As openElement.WebElement.Editors.Control.CtlEditListOf.EditConfig
            Dim addButtonList As New List(Of AddButton)
            addButtonList.Add(New AddButton("AddImage", My.Resources.text.LocalizableFormAndConverter._0111, Nothing, False))
            Dim editConfig As New EditConfig(My.Resources.text.LocalizableFormAndConverter._0113, My.Resources.text.LocalizableFormAndConverter._0112, addButtonList)
            Return editConfig
        End Function
#End Region

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("ContentLightBox"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            MyBase.RenderEndTag(writer)
        End Sub

    End Class
End Namespace
