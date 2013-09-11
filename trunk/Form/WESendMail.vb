Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.ElementWECommon.Form.Forms

Namespace Elements.Form

    <Serializable()> _
    Public Class WESendMail
        Inherits ElementBase

#Region "Private variable"
        Private _TempCulture As String = Page.Culture

        Private _FormLinks As DataType.FormLinks
        Private _SendMailInfo As FrmWESendMailConfig.WESendMailInfo

        <Common.Attributes.ContainsLinks()> _
        Private _SendMailResponse As FrmWESendMailConfig.WESendMailResponse

        <NonSerialized()> Private _SenMailConfig As FrmWESendMailConfig.WeSendMailConfig 'wizard
#End Region

#Region "Properties"
        <Browsable(False), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js)> _
        Public Property TempCulture() As String
            Get
                Return _TempCulture
            End Get
            Set(ByVal value As String)
                _TempCulture = value
            End Set
        End Property

        ''' <summary>
        ''' Forms links and buttons list
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.All), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property FormLinks() As DataType.FormLinks
            Get
                If _FormLinks Is Nothing Then _FormLinks = New DataType.FormLinks()
                Return _FormLinks
            End Get
            Set(ByVal value As DataType.FormLinks)
                _FormLinks = value
            End Set
        End Property

        <Browsable(False), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property SendMailInfo() As FrmWESendMailConfig.WESendMailInfo
            Get
                If _SendMailInfo Is Nothing Then _SendMailInfo = New FrmWESendMailConfig.WESendMailInfo()
                Return _SendMailInfo
            End Get
            Set(ByVal value As FrmWESendMailConfig.WESendMailInfo)
                _SendMailInfo = value
            End Set
        End Property

        <Browsable(False), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property SendMailResponse() As FrmWESendMailConfig.WESendMailResponse
            Get
                If _SendMailResponse Is Nothing Then _SendMailResponse = New FrmWESendMailConfig.WESendMailResponse()
                Return _SendMailResponse
            End Get
            Set(ByVal value As FrmWESendMailConfig.WESendMailResponse)
                _SendMailResponse = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N001"), _
        Ressource.localizable.LocalizableDescAtt("_D081"), _
        Editor(GetType(Editors.UITypeWESendMailConfig), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property SenMailConfig() As FrmWESendMailConfig.WeSendMailConfig
            Get
                Return New FrmWESendMailConfig.WeSendMailConfig( _
                        openElement.Serialization.Clone(Me.FormLinks), _
                        openElement.Serialization.Clone(Me.SendMailInfo), _
                        openElement.Serialization.Clone(Me.SendMailResponse))
            End Get
            Set(ByVal value As FrmWESendMailConfig.WeSendMailConfig)
                Me.FormLinks = value.FormLinks
                Me.SendMailInfo = value.SendMailInfo
                Me.SendMailResponse = value.SendMailResponse
            End Set
        End Property

        ''' <summary>
        ''' php send email config  
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks> open in oe,all update and record is in oe</remarks>
        <Browsable(True), _
        Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
        Ressource.localizable.LocalizableNameAtt("_N152"), _
        Ressource.localizable.LocalizableDescAtt("_D152"), _
        Editor(GetType(openElement.WebSite.Config.Editor.UITypeConfigSendMail), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public ReadOnly Property ConfSendMail() As openElement.WebSite.Config.Type.ConfigSendMail
            Get
                Return openElement.Tools.Various.GetConfigSendMail
            End Get
        End Property

#End Region

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.HiddenEdit, "WESendMail", page, parentID, templateName)
        End Sub


        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0090
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupForm"
            info.ToolBoxIco = My.Resources.WESendMail
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0091
            info.SortPropertyList.Add(New SortProperty("SenMailConfig", "Tools.png", My.Resources.text.LocalizableOpen._0092))
            info.AutoOpenProperty = "SenMailConfig"
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Me.DisabledStyles = True

            MyBase.OnOpen()

        End Sub


        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(Common.EnuScriptType.Php, "ElementsLibrary\Common\Server\WESendMail.php", "WEFiles/Server/WESendMail.php")
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WESendMail.js", "WEFiles/Client/WESendMail.js") ', False)
            MyBase.AddSharedScripts(Common.EnuSharedScript.jQueryForm)
            MyBase.AddSharedScripts(Common.EnuSharedScript.openElementUI)
            MyBase.AddSharedScripts(Common.EnuSharedScript.jQuerySimplemodal)
            MyBase.OnInitExternalFiles()
        End Sub

#End Region

#Region "DD Translation of LocalizableStrings"

        ' See comments in ElementBase class
        Public Overrides Function GetLocalizableStringsForTranslationSystem( _
                                        ByVal accListLS As Dictionary(Of String, DataType.LocalizableString), _
                                        ByVal accListInfo As Dictionary(Of String, String), _
                                        Optional ByVal onlyNonEmpty As Boolean = True) As Boolean

            Dim r As Boolean = False

            If _SendMailResponse Is Nothing Then Return r

            r = r Or AddLSForTranslationSystem(_SendMailResponse.NoPopupMessage, "NoPopupMessage", "WESendMail", "SendMail", accListLS, accListInfo, onlyNonEmpty)
            r = r Or AddLSForTranslationSystem(_SendMailResponse.OkpopupMessage, "NoPopupMessage", "WESendMail", "SendMail", accListLS, accListInfo, onlyNonEmpty)

            Return r
        End Function

#End Region

    End Class

 
End Namespace



