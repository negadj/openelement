Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Web.UI
Imports System.Windows.Forms

Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Control
Imports openElement.WebElement.Elements
Imports openElement.WebElement.ElementWECommon.Interactivity.Forms
Imports openElement.WebElement.StylesManager

Imports WebElement.My.Resources.text

Namespace Elements.Interactivity

    <Serializable> _
    Public Class WELightBox1
        Inherits ElementBase

        #Region "Fields"

        ''' <summary>
        ''' main config
        ''' </summary>
        ''' <remarks></remarks>
        <ContainsLinks> _
        Private _ConfigLightBox1 As List(Of FrmLightBox1.ImgLightBoxConfig)

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.HiddenEdit, "WELightBox1", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Editor(GetType(UITypeEditListOf), GetType(UITypeEditor)), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property ConfigLightBox1() As List(Of FrmLightBox1.ImgLightBoxConfig)
            Get
                If _ConfigLightBox1 Is Nothing Then _ConfigLightBox1 = New List(Of FrmLightBox1.ImgLightBoxConfig)
                Return _ConfigLightBox1
            End Get
            Set(ByVal value As List(Of FrmLightBox1.ImgLightBoxConfig))
                _ConfigLightBox1 = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As CtlEditListOf.AddButton, ByVal selectedNodeTag As CtlEditListOf.NodeTag) As List(Of Object)
            Dim newObs As New List(Of Object)
            If addButton.Name = "AddImage" Then
                Dim elementsFilter As New String("WEImage")
                Dim wizzardLightBox As New FrmLightBox1(Me, elementsFilter)
                If wizzardLightBox.ShowDialog = DialogResult.OK Then
                    newObs.Add(wizzardLightBox.ImgLightBox)
                End If

            End If
            Return newObs
        End Function

        Protected Overrides Function OnFrmEditListOfGetFormConfig() As CtlEditListOf.EditConfig
            Dim addButtonList As New List(Of CtlEditListOf.AddButton)
            addButtonList.Add(New CtlEditListOf.AddButton("AddImage", LocalizableFormAndConverter._0111, Nothing, False))
            Dim editConfig As New CtlEditListOf.EditConfig(LocalizableFormAndConverter._0113, LocalizableFormAndConverter._0112, addButtonList)
            Return editConfig
        End Function

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0204
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupInteractivity"
            info.ToolBoxIco = My.Resources.WEGallery1
            info.ToolBoxDescription = LocalizableOpen._0205
            info.AutoOpenProperty = "ConfigLightBox1"
            info.SortPropertyList.Add(New SortProperty("ConfigLightBox1", "Tools.png", LocalizableOpen._0030))
            Return info
        End Function

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(EnuScriptType.Css, "ElementsLibrary\Common\Css\WELightBox1.css", "WEFiles/Css/WELightBox1.css")
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WELightBox1.js", "WEFiles/Client/WELightBox1.js")
            MyBase.OnInitExternalFiles()
        End Sub

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)

            configStylesZones.Add(New ConfigStylesZone("ContentLightBox", LocalizableOpen._0207, LocalizableOpen._0331))
            configStylesZones.Add(New ConfigStylesZone("LeaveLightBox", LocalizableOpen._0208, LocalizableOpen._0330))
            configStylesZones.Add(New ConfigStylesZone("GoRightLightBox", LocalizableOpen._0209, LocalizableOpen._0209))
            configStylesZones.Add(New ConfigStylesZone("GoLeftLightBox", LocalizableOpen._0210, LocalizableOpen._0210))
            configStylesZones.Add(New ConfigStylesZone("TitleLightBox", LocalizableOpen._0211, LocalizableOpen._0211))
            configStylesZones.Add(New ConfigStylesZone("OverviewLightBox", LocalizableOpen._0212, LocalizableOpen._0212))
            configStylesZones.Add(New ConfigStylesZone("LinkLightBox", LocalizableOpen._0332, LocalizableOpen._0333))
            configStylesZones.Add(New ConfigStylesZone("MaskLightBox", LocalizableOpen._0328, LocalizableOpen._0329))

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("ContentLightBox"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

    End Class

End Namespace

