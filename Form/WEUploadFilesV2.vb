Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Elements
Imports openElement.WebElement.StylesManager

Imports WebElement.Elements.Form.Editors.Converter
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Form

    <Serializable> _
    Public Class WEUploadFilesV2
        Inherits WEFormFieldBase

        #Region "Fields"

        Private _AllowedSize As String
        Private _AllowedTypesExt As String
        Private _InputReadOnly As Boolean
        Private _Multiple As Boolean
        Private _Validator As Validator

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New("WEUploadFiles2", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        ''' <summary>
        ''' Max size of files to import
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N047"), _
        LocalizableDescAtt("_D047"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        TypeConverter(GetType(TConvUploadFileSize)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property AllowedSize() As String
            Get
                If String.IsNullOrEmpty(_AllowedSize) Then _AllowedSize = 1
                If _AllowedSize = "0" Then _AllowedSize = 1
                Return _AllowedSize
            End Get
            Set(ByVal value As String)
                If Long.TryParse(value, New Long) Then
                    _AllowedSize = value
                Else
                    _AllowedSize = 1
                End If

            End Set
        End Property

        ''' <summary>
        '''List of allowed extensions (Ex:. Jpg, png.) Files to import 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N046"), _
        LocalizableDescAtt("_D046"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property AllowedTypesExt() As String
            Get
                If _AllowedTypesExt Is Nothing Then _AllowedTypesExt = ".png,.gif,.jpg,.jpeg,.doc,.docx,.xls,.xlsx,.rtf,.txt,.pdf,.odg,.odt,.ods,.odf,.odp,.odb"
                Return _AllowedTypesExt
            End Get
            Set(ByVal value As String)
                _AllowedTypesExt = value
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

        ''' <summary>
        ''' True if we can upload several files
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Expert), _
        Ressource.localizable.LocalizableNameAtt("_N212"), _
        LocalizableDescAtt("_D212"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Multiple() As Boolean
            Get
                Return _Multiple
            End Get
            Set(ByVal value As Boolean)
                _Multiple = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N051"), _
        LocalizableDescAtt("_D051"), _
        Editor(GetType(UITypeValidator), GetType(UITypeEditor)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Validator() As Validator
            Get
                If _Validator Is Nothing Then _Validator = New Validator(Validator.TypeValueToValidate.Text)
                Return _Validator
            End Get
            Set(ByVal value As Validator)
                _Validator = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0073
            info.ToolBoxIco = My.Resources.WEUploadFiles
            info.ToolBoxDescription = LocalizableOpen._0074
            info.ScriptVarName = "OEConfWEUploadFiles"
            info.SortPropertyList.Add(New SortProperty("Validator", "Valid.png", LocalizableOpen._0081))
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("InputFile", LocalizableOpen._0119, LocalizableOpen._0120))
            configStylesZones.Add(New ConfigStylesZone("InputFileError", LocalizableOpen._0364, LocalizableOpen._0364))
            configStylesZones.Add(New ConfigStylesZone("Validator", LocalizableOpen._0365, LocalizableOpen._0365))
            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            writer.WriteBeginTag("input")
            writer.WriteAttribute("name", Me.InputName)
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("InputFile"))
            If Multiple = True Then writer.WriteAttribute("multiple", Multiple)
            writer.WriteAttribute("type", "file")
            If Me.InputReadOnly Then writer.WriteAttribute("disabled", "disabled")
            writer.Write(HtmlTextWriter.SelfClosingTagEnd)

            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

    End Class

End Namespace

