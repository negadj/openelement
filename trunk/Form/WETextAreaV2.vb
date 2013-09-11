Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel

Namespace Elements.Form

 
    <Serializable()> _
Public Class WETextAreaV2
        Inherits WEFormFieldBase

#Region "Private variable"

        Private _TextAreaValue As DataType.LocalizableString
        Private _InputReadOnly As Boolean
        Private _NoResize As Boolean

        Private _Validator As DataType.Validator

#End Region

#Region "Properties"
        
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
         Ressource.localizable.LocalizableNameAtt("_N054"), _
         Ressource.localizable.LocalizableDescAtt("_D054"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
        Common.Attributes.MemoEditor(), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property TextAreaValue() As DataType.LocalizableString
            Get
                If _TextAreaValue Is Nothing Then _TextAreaValue = New DataType.LocalizableString("")
                Return _TextAreaValue
            End Get
            Set(ByVal value As DataType.LocalizableString)
                _TextAreaValue = value
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

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N213"), _
        Ressource.localizable.LocalizableDescAtt("_D213"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NoResize() As Boolean
            Get
                Return _NoResize
            End Get
            Set(ByVal value As Boolean)
                _NoResize = value
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
            MyBase.New("WETextArea2", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.Both
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0087
            info.ToolBoxIco = My.Resources.WETextArea
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0088
            info.ScriptVarName = "OEConfWETextArea"
            info.SortPropertyList.Add(New SortProperty("Validator", "Valid.png", My.Resources.text.LocalizableOpen._0081))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("TextArea", My.Resources.text.LocalizableOpen._0083, My.Resources.text.LocalizableOpen._0089)) '"Boite de saisie","Zone de saisie du texte."
            configStylesZones.Add(New StylesManager.ConfigStylesZone("TextAreaError", My.Resources.text.LocalizableOpen._0364, My.Resources.text.LocalizableOpen._0364)) 'Champ en erreur
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Validator", My.Resources.text.LocalizableOpen._0365, My.Resources.text.LocalizableOpen._0365)) 'Icône et texte d'erreur
      
            MyBase.OnOpen(configStylesZones)
        End Sub

#End Region


#Region "Render"
        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)

            DTWriteBeginTag("textarea", writer)
            DTWriteAttrStatic("class", MyBase.GetStyleZoneClass("TextArea"))
            DTWriteAttrStatic("name", InputName)

            If NoResize Then
                DTWriteAttrDynamic("style", , , "resize:none")
            Else
                DTWriteAttrDynamic("style")
            End If


            If Me.InputReadOnly Then DTWriteAttrStatic("disabled", "disabled")
            DTWriteAttrStatic("rows", "3")
            DTWriteAttrStatic("cols", "50")
            DTTagEndDeclaration()

            DTWriteInnerHtmlDynamic(, , Me.TextAreaValue.GetValue(MyBase.Page.Culture))

            DTWriteEndTag("textarea")

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
            r = r Or AddFrmFieldLSForTranslationSystem(_TextAreaValue, "TextAreaValue", "TextArea Multiline", accListLS, accListInfo, onlyNonEmpty)
            Return r
        End Function

#End Region

    End Class
End Namespace
