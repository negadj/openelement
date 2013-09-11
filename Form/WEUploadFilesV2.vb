Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel

Namespace Elements.Form

    <Serializable()> _
    Public Class WEUploadFilesV2
        Inherits WEFormFieldBase

#Region "Private variable"

        Private _AllowedTypesExt As String
        Private _AllowedSize As String
        Private _InputReadOnly As Boolean
        Private _Multiple As Boolean
        Private _Validator As DataType.Validator

#End Region

#Region "Properties"

        ''' <summary>
        '''List of allowed extensions (Ex:. Jpg, png.) Files to import 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N046"), _
        Ressource.localizable.LocalizableDescAtt("_D046"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property AllowedTypesExt() As String
            Get
                If _AllowedTypesExt Is Nothing Then _AllowedTypesExt = ".png,.gif,.jpg,.jpeg,.doc,.docx,.xls,.xlsx,.rtf,.txt,.pdf,.odg,.odt,.ods,.odf,.odp,.odb"
                Return _AllowedTypesExt
            End Get
            Set(ByVal value As String)
                _AllowedTypesExt = value
            End Set
        End Property

        ''' <summary>
        ''' Max size of files to import
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N047"), _
        Ressource.localizable.LocalizableDescAtt("_D047"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        TypeConverter(GetType(Elements.Form.Editors.Converter.TConvUploadFileSize)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
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

        ''' <summary>
        ''' True if we can upload several files
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Expert), _
       Ressource.localizable.LocalizableNameAtt("_N212"), _
       Ressource.localizable.LocalizableDescAtt("_D212"), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
       Public Property Multiple() As Boolean
            Get
                Return _Multiple
            End Get
            Set(ByVal value As Boolean)
                _Multiple = value
            End Set
        End Property

#End Region

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New("WEUploadFiles2", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0073
            info.ToolBoxIco = My.Resources.WEUploadFiles
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0074
            info.ScriptVarName = "OEConfWEUploadFiles"
            info.SortPropertyList.Add(New SortProperty("Validator", "Valid.png", My.Resources.text.LocalizableOpen._0081))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("InputFile", My.Resources.text.LocalizableOpen._0119, My.Resources.text.LocalizableOpen._0120))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("InputFileError", My.Resources.text.LocalizableOpen._0364, My.Resources.text.LocalizableOpen._0364))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Validator", My.Resources.text.LocalizableOpen._0365, My.Resources.text.LocalizableOpen._0365))
            MyBase.OnOpen(configStylesZones)
        End Sub

#End Region
#Region "Render"

        Protected Overrides Sub Render(ByVal writer As openElement.WebElement.Common.HtmlWriter)
            MyBase.RenderBeginTag(writer)

            writer.WriteBeginTag("input")
            writer.WriteAttribute("name", Me.InputName)
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("InputFile"))
            If Multiple = True Then writer.WriteAttribute("multiple", Multiple)
            writer.WriteAttribute("type", "file")
            If Me.InputReadOnly Then writer.WriteAttribute("disabled", "disabled")
            writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)

            MyBase.RenderEndTag(writer)
        End Sub
#End Region


    End Class

End Namespace
