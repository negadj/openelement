Imports System.ComponentModel
Imports System.Drawing.Design

Imports openElement.WebElement
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Elements
Imports openElement.WebElement.StylesManager

Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Form

    <Serializable> _
    Public Class WECheckBoxV2
        Inherits WEFormFieldBase

        #Region "Fields"

        ''' <summary>
        ''' true if the check is checked 
        ''' </summary>
        ''' <remarks></remarks>
        Private _Checked As Boolean
        Private _InputReadOnly As Boolean

        ''' <summary>
        ''' forms validator
        ''' </summary>
        ''' <remarks></remarks>
        Private _Validator As Validator

        ''' <summary>
        ''' check value (text)
        ''' </summary>
        ''' <remarks></remarks>
        Private _Value As LocalizableString

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New("WECheckBox2", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        ''' <summary>
        ''' true if the checkbox is checked
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N078"), _
        LocalizableDescAtt("_D078"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Checked() As Boolean
            Get
                Return _Checked
            End Get
            Set(ByVal value As Boolean)
                _Checked = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N057"), _
        LocalizableDescAtt("_D077"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property InputReadOnly() As Boolean
            Get
                Return _InputReadOnly
            End Get
            Set(ByVal value As Boolean)
                _InputReadOnly = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N051"), _
        LocalizableDescAtt("_D051"), _
        Editor(GetType(UITypeValidator), GetType(UITypeEditor)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Validator() As Validator
            Get
                If _Validator Is Nothing Then _Validator = New Validator(Validator.TypeValueToValidate.Bool)
                Return _Validator
            End Get
            Set(ByVal value As Validator)
                _Validator = value
            End Set
        End Property

        ''' <summary>
        ''' text field associate at the check box
        ''' </summary>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N075"), _
        LocalizableDescAtt("_D075"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element), _
        TypeConverter(GetType(TConvLocalizableString))> _
        Public Property Value() As LocalizableString
            Get
                If _Value Is Nothing Then _Value = New LocalizableString(LocalizablePropertyDefaultValue._0009) '"Valeur du champ")
                Return _Value
            End Get
            Set(ByVal value As LocalizableString)
                _Value = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0103
            info.ToolBoxIco = My.Resources.WECheckbox
            info.ToolBoxDescription = LocalizableOpen._0104
            info.ScriptVarName = "OEConfWECheckBox"
            info.SortPropertyList.Add(New SortProperty("Validator", "Valid.png", LocalizableOpen._0081))
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("CheckBox", LocalizableOpen._0115, LocalizableOpen._0116)) '"Case à cocher", "Zone de la case à cocher."
            configStylesZones.Add(New ConfigStylesZone("CheckBoxError", LocalizableOpen._0364, LocalizableOpen._0364)) 'Champ en erreur
            configStylesZones.Add(New ConfigStylesZone("Validator", LocalizableOpen._0365, LocalizableOpen._0365)) 'Icône et texte d'erreur
             MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            DTWriteBeginTag("input", writer)
            DTWriteAttribute("type", "checkbox")
            DTWriteAttribute("class", MyBase.GetStyleZoneClass("CheckBox"))
            DTWriteAttrDynamic("style", , , , True)
            DTWriteAttribute("name", Me.InputName)
            DTWriteAttribute("value", Me.Value.GetValue(MyBase.Page.Culture))

            If Me.InputReadOnly Then DTWriteAttribute("disabled", "disabled")

            If IsDynamic Then
                Dim checked As String = "" : If Me.Checked Then checked = "checked"
                DTWriteAttrDynamic("checked", , , checked) ' dynamic attribute
            Else
                If Me.Checked Then DTWriteAttribute("checked", "checked")
            End If

            DTSelfClosingTagEnd()

            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

    End Class

End Namespace

