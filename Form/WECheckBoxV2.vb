Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel

Namespace Elements.Form

    <Serializable()> _
    Public Class WECheckBoxV2
        Inherits WEFormFieldBase

        Private _InputReadOnly As Boolean
        ''' <summary>
        ''' true if the check is checked 
        ''' </summary>
        ''' <remarks></remarks>
        Private _Checked As Boolean
        ''' <summary>
        ''' check value (text)
        ''' </summary>
        ''' <remarks></remarks>
        Private _Value As DataType.LocalizableString
        
        ''' <summary>
        ''' forms validator
        ''' </summary>
        ''' <remarks></remarks>
        Private _Validator As DataType.Validator

#Region "Properties"

        ''' <summary>
        ''' text field associate at the check box
        ''' </summary>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N075"), _
        Ressource.localizable.LocalizableDescAtt("_D075"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString))> _
        Public Property Value() As DataType.LocalizableString
            Get
                If _Value Is Nothing Then _Value = New DataType.LocalizableString(My.Resources.text.LocalizablePropertyDefaultValue._0009) '"Valeur du champ")
                Return _Value
            End Get
            Set(ByVal value As DataType.LocalizableString)
                _Value = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N057"), _
        Ressource.localizable.LocalizableDescAtt("_D077"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property InputReadOnly() As Boolean
            Get
                Return _InputReadOnly
            End Get
            Set(ByVal value As Boolean)
                _InputReadOnly = value
            End Set
        End Property

        ''' <summary>
        ''' true if the checkbox is checked
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N078"), _
        Ressource.localizable.LocalizableDescAtt("_D078"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Checked() As Boolean
            Get
                Return _Checked
            End Get
            Set(ByVal value As Boolean)
                _Checked = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N051"), _
        Ressource.localizable.LocalizableDescAtt("_D051"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeValidator), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Validator() As DataType.Validator
            Get
                If _Validator Is Nothing Then _Validator = New DataType.Validator(DataType.Validator.TypeValueToValidate.Bool)
                Return _Validator
            End Get
            Set(ByVal value As DataType.Validator)
                _Validator = value
            End Set
        End Property

#End Region

#Region "Builder required function "

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New("WECheckBox2", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0103
            info.ToolBoxIco = My.Resources.WECheckbox
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0104
            info.ScriptVarName = "OEConfWECheckBox"
            info.SortPropertyList.Add(New SortProperty("Validator", "Valid.png", My.Resources.text.LocalizableOpen._0081))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("CheckBox", My.Resources.text.LocalizableOpen._0115, My.Resources.text.LocalizableOpen._0116)) '"Case à cocher", "Zone de la case à cocher."
            configStylesZones.Add(New StylesManager.ConfigStylesZone("CheckBoxError", My.Resources.text.LocalizableOpen._0364, My.Resources.text.LocalizableOpen._0364)) 'Champ en erreur
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Validator", My.Resources.text.LocalizableOpen._0365, My.Resources.text.LocalizableOpen._0365)) 'Icône et texte d'erreur
             MyBase.OnOpen(configStylesZones)
        End Sub

#End Region

#Region "Render"
        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

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

#End Region

    End Class

End Namespace