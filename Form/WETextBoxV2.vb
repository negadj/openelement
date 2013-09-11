Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel

Namespace Elements.Form

    <Serializable()> _
    Public Class WETextBoxV2
        Inherits WEFormFieldBase

        Public Enum EnuTextBoxtype As Integer
            text = 0
            password = 1
        End Enum

#Region "Private variable"

        Private _InputValue As DataType.LocalizableString
        Private _ImputMaxLenght As Integer
        Private _Typ As EnuTextBoxtype
        Private _InputReadOnly As Boolean
        Private _InputTitle As LocalizableString
        Private _AutoComplete As Boolean

        Private _Validator As DataType.Validator

#End Region

#Region "Proprietes"

        ''' <summary>
        ''' text field value
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N054"), _
        Ressource.localizable.LocalizableDescAtt("_D054"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property InputValue() As DataType.LocalizableString
            Get
                If _InputValue Is Nothing Then _InputValue = New DataType.LocalizableString()
                Return _InputValue
            End Get
            Set(ByVal value As DataType.LocalizableString)
                _InputValue = value
            End Set
        End Property

       ''' <summary>
        ''' Max characters number (with space). Set 0 for an infinite characters
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N056"), _
        Ressource.localizable.LocalizableDescAtt("_D056"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property ImputMaxLenght() As Integer
            Get
                Return _ImputMaxLenght
            End Get
            Set(ByVal value As Integer)
                _ImputMaxLenght = value
            End Set
        End Property
        
        ''' <summary>
        ''' input's type
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N210"), _
        Ressource.localizable.LocalizableDescAtt("_D210"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Typ() As EnuTextBoxtype
            Get
                Return _Typ
            End Get
            Set(ByVal value As EnuTextBoxtype)
                _Typ = value
            End Set
        End Property

        ''' <summary>
        ''' true if read only
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
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

        
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N211"), _
        Ressource.localizable.LocalizableDescAtt("_D211"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property AutoComplete() As Boolean
            Get
                Return _AutoComplete
            End Get
            Set(ByVal value As Boolean)
                _AutoComplete = value
            End Set
        End Property

     
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N051"), _
        Ressource.localizable.LocalizableDescAtt("_D051"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeValidator), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Validator() As DataType.Validator
            Get
                If _Validator Is Nothing Then _Validator = New DataType.Validator(DataType.Validator.TypeValueToValidate.Text)
                Return _Validator
            End Get
            Set(ByVal value As DataType.Validator)
                _Validator = value
            End Set
        End Property


#End Region

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New("WETextBox2", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.Width

            _AutoComplete = True
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0083
            info.ToolBoxIco = My.Resources.WETextBox
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0084
            info.ScriptVarName = "OEConfWETextBox"
            info.SortPropertyList.Add(New SortProperty("Validator", "Valid.png", My.Resources.text.LocalizableOpen._0081))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("TextBox", My.Resources.text.LocalizableOpen._0083, My.Resources.text.LocalizableOpen._0089))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("TextBoxError", My.Resources.text.LocalizableOpen._0364, My.Resources.text.LocalizableOpen._0364))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Validator", My.Resources.text.LocalizableOpen._0365, My.Resources.text.LocalizableOpen._0365))
            MyBase.OnOpen(configStylesZones)
        End Sub
#End Region

#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)
            MyBase.RenderBeginTag(writer)


            ' dynamic render, or static if dyn mode not active for this element:

            DTWriteBeginTag("input", writer) '                                   writer.WriteBeginTag("input")

            DTWriteAttrStatic("name", Me.InputName) ' check if need dynamic    ' writer.WriteAttribute("name", Me.InputName)
            DTWriteAttrStatic("type", Me.Typ.ToString) '                         writer.WriteAttribute("type", Me.Typ.ToString)
            If Me.InputReadOnly Then DTWriteAttrStatic("disabled", "disabled") ' writer.WriteAttribute("disabled", "disabled")

            Dim StrAutoComplete As String
            If AutoComplete Then StrAutoComplete = "on" Else StrAutoComplete = "off" 'on affiche pas autocomplete, si non necessaire (conformite w3c)
            If Not AutoComplete Then DTWriteAttrStatic("autocomplete", StrAutoComplete)

            DTWriteAttrStatic("class", MyBase.GetStyleZoneClass("TextBox"))
            DTWriteAttrDynamic("style") ' ex to be able to hide it

            Dim inputValue As String = Me.InputValue.GetValue(MyBase.Page.Culture)
            If Not String.IsNullOrEmpty(inputValue) OrElse IsDynamic Then
                DTWriteAttrDynamic("value", , , inputValue) ' dynamic value
            End If
            If Me.ImputMaxLenght <> 0 Then DTWriteAttrStatic("maxlength", Me.ImputMaxLenght)

            DTSelfClosingTagEnd() ' writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)


            MyBase.RenderEndTag(writer)
        End Sub
#End Region


#Region "DD Translation of LocalizableStrings"

        ' See comments in ElementBase class
        Public Overrides Function GetLocalizableStringsForTranslationSystem( _
                                        ByVal accListLS As Dictionary(Of String, DataType.LocalizableString), _
                                        ByVal accListInfo As Dictionary(Of String, String), _
                                        Optional ByVal onlyNonEmpty As Boolean = True) As Boolean

            Dim r As Boolean = False
            r = r Or AddFrmFieldLSForTranslationSystem(_InputTitle, "InputTitle", "TextBox", accListLS, accListInfo, onlyNonEmpty)
            r = r Or AddFrmFieldLSForTranslationSystem(_InputValue, "InputValue", "TextBox", accListLS, accListInfo, onlyNonEmpty)
            Return r
        End Function

#End Region

    End Class

End Namespace
