Imports System.ComponentModel
Imports System.Drawing.Design

Imports openElement
Imports openElement.Tools
Imports openElement.WebElement
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Elements
Imports openElement.WebElement.ElementWECommon.Form.Forms
Imports openElement.WebSite.Config.Editor
Imports openElement.WebSite.Config.Type

Imports WebElement.Elements.Form.Editors
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Form

    <Serializable> _
    Public Class WESendMail
        Inherits ElementBase

        #Region "Fields"

        Private _FormLinks As FormLinks
        Private _SendMailInfo As FrmWESendMailConfig.WESendMailInfo
        <ContainsLinks> _
        Private _SendMailResponse As FrmWESendMailConfig.WESendMailResponse
        Private _TempCulture As String = Page.Culture

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.HiddenEdit, "WESendMail", page, parentID, templateName)
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        ''' <summary>
        ''' php send email config  
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks> open in oe,all update and record is in oe</remarks>
        <Browsable(True), _
        Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
        Ressource.localizable.LocalizableNameAtt("_N152"), _
        LocalizableDescAtt("_D152"), _
        Editor(GetType(UITypeConfigSendMail), GetType(UITypeEditor)), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public ReadOnly Property ConfSendMail() As ConfigSendMail
            Get
                Return Various.GetConfigSendMail
            End Get
        End Property

        ''' <summary>
        ''' Forms links and buttons list
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.All), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property FormLinks() As FormLinks
            Get
                If _FormLinks Is Nothing Then _FormLinks = New FormLinks()
                Return _FormLinks
            End Get
            Set(ByVal value As FormLinks)
                _FormLinks = value
            End Set
        End Property

        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
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
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
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
        LocalizableDescAtt("_D081"), _
        Editor(GetType(UITypeWESendMailConfig), GetType(UITypeEditor)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property SenMailConfig() As FrmWESendMailConfig.WeSendMailConfig
            Get
                Return New FrmWESendMailConfig.WeSendMailConfig( _
                        Serialization.Clone(Me.FormLinks), _
                        Serialization.Clone(Me.SendMailInfo), _
                        Serialization.Clone(Me.SendMailResponse))
            End Get
            Set(ByVal value As FrmWESendMailConfig.WeSendMailConfig)
                Me.FormLinks = value.FormLinks
                Me.SendMailInfo = value.SendMailInfo
                Me.SendMailResponse = value.SendMailResponse
            End Set
        End Property

        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Js)> _
        Public Property TempCulture() As String
            Get
                Return _TempCulture
            End Get
            Set(ByVal value As String)
                _TempCulture = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        ' See comments in ElementBase class
        Public Overrides Function GetLocalizableStringsForTranslationSystem( _
            ByVal accListLS As Dictionary(Of String, LocalizableString), _
            ByVal accListInfo As Dictionary(Of String, String), _
            Optional ByVal onlyNonEmpty As Boolean = True) As Boolean
            Dim r As Boolean = False

            If _SendMailResponse Is Nothing Then Return r

            r = r Or AddLSForTranslationSystem(_SendMailResponse.NoPopupMessage, "NoPopupMessage", "WESendMail", "SendMail", accListLS, accListInfo, onlyNonEmpty)
            r = r Or AddLSForTranslationSystem(_SendMailResponse.OkpopupMessage, "NoPopupMessage", "WESendMail", "SendMail", accListLS, accListInfo, onlyNonEmpty)

            Return r
        End Function

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0090
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupForm"
            info.ToolBoxIco = My.Resources.WESendMail
            info.ToolBoxDescription = LocalizableOpen._0091
            info.SortPropertyList.Add(New SortProperty("SenMailConfig", "Tools.png", LocalizableOpen._0092))
            info.AutoOpenProperty = "SenMailConfig"
            Return info
        End Function

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(EnuScriptType.Php, "ElementsLibrary\Common\Server\WESendMail.php", "WEFiles/Server/WESendMail.php")
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WESendMail.js", "WEFiles/Client/WESendMail.js") ', False)
            MyBase.AddSharedScripts(EnuSharedScript.jQueryForm)
            MyBase.AddSharedScripts(EnuSharedScript.openElementUI)
            MyBase.AddSharedScripts(EnuSharedScript.jQuerySimplemodal)
            MyBase.OnInitExternalFiles()
        End Sub

        Protected Overrides Sub OnOpen()
            Me.DisabledStyles = True

            MyBase.OnOpen()
        End Sub

        #End Region 'Methods

    End Class

End Namespace

