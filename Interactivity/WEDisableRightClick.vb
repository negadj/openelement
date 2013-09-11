Imports openElement.WebElement
Imports openElement.WebElement.Elements
Imports System.ComponentModel

Namespace Elements.Interactivity
    <Serializable()> _
    Public Class WEDisableRightClick
        Inherits ElementBase

        Private _Text As DataType.LocalizableString

#Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
       Ressource.localizable.LocalizableNameAtt("_N099"), _
       Ressource.localizable.LocalizableDescAtt("_N099"), _
       TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
       Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
       Common.Attributes.MemoEditor(), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
       Public Property Text() As DataType.LocalizableString
            Get
                If _Text Is Nothing Then _Text = New DataType.LocalizableString(My.Resources.text.LocalizablePropertyDefaultValue._0017)
                Return _Text
            End Get
            Set(ByVal value As DataType.LocalizableString)
                _Text = value
            End Set
        End Property
#End Region

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.HiddenEdit, "WEDisableRightClick", page, parentID, templateName)
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0121
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupInteractivity"
            info.ToolBoxIco = My.Resources.WEAlertBox
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0122
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            MyBase.DisabledStyles = True

            MyBase.OnOpen()

        End Sub

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WEDisableRightClick.js", "WEFiles/Client/WEDisableRightClick.js")
            MyBase.OnInitExternalFiles()
        End Sub

#End Region


    End Class
End Namespace
