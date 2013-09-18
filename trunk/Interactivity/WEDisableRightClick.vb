Imports System.ComponentModel

Imports openElement.WebElement
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Elements

Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Interactivity

    <Serializable> _
    Public Class WEDisableRightClick
        Inherits ElementBase

        #Region "Fields"

        Private _Text As LocalizableString

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.HiddenEdit, "WEDisableRightClick", page, parentID, templateName)
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N099"), _
        LocalizableDescAtt("_N099"), _
        TypeConverter(GetType(TConvLocalizableString)), _
        ExportVar(ExportVar.EnuVarType.Js), _
        MemoEditor, _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Text() As LocalizableString
            Get
                If _Text Is Nothing Then _Text = New LocalizableString(LocalizablePropertyDefaultValue._0017)
                Return _Text
            End Get
            Set(ByVal value As LocalizableString)
                _Text = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0121
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupInteractivity"
            info.ToolBoxIco = My.Resources.WEAlertBox
            info.ToolBoxDescription = LocalizableOpen._0122
            Return info
        End Function

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WEDisableRightClick.js", "WEFiles/Client/WEDisableRightClick.js")
            MyBase.OnInitExternalFiles()
        End Sub

        Protected Overrides Sub OnOpen()
            MyBase.DisabledStyles = True

            MyBase.OnOpen()
        End Sub

        #End Region 'Methods

    End Class

End Namespace

