'Imports openElement.WebElement.Elements
'Imports openElement.WebElement
'Imports System.ComponentModel

'Namespace Elements.Interactivity


'    <Serializable(), Common.ContainsLinksAtt(False)> _
'    Public Class WEAlertBox   'Element Hidden 
'        Inherits ElementBase

'#Region "Propriété"

'        Private _Text As DataType.LocalizableString
'        Private _DesactivatePreview As Boolean

'        '<Category("Edition"), _
'        'DisplayName("Texte"), _
'        'Description("Edition du texte du message d'alerte"), _
'        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
'        Ressource.localizable.LocalizableNameAtt("_N007"), _
'        Ressource.localizable.LocalizableDescAtt("_D043"), _
'        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString))> _
'        Public Property Text() As DataType.LocalizableString
'            Get
'                If _Text Is Nothing Then
'                    _Text = New DataType.LocalizableString(My.Resources.text.LocalizableProperty._0006) '"Mon message ...")
'                End If
'                Return _Text
'            End Get
'            Set(ByVal value As DataType.LocalizableString)
'                _Text = value
'            End Set
'        End Property

'        '<Category("Mode édition"), _
'        'DisplayName("Désactiver"), _
'        'Description("Désactiver le message pendant l'édition de la page")> _
'        <Ressource.localizable.LocalizableCatAtt("_Att04"), _
'        Ressource.localizable.LocalizableNameAtt("_N044"), _
'        Ressource.localizable.LocalizableDescAtt("_D044")> _
'        Public Property DesactivatePreview() As Boolean
'            Get
'                Return _DesactivatePreview
'            End Get
'            Set(ByVal value As Boolean)
'                _DesactivatePreview = value
'            End Set
'        End Property

'#End Region

'        Public Sub New(ByVal Page As Page, ByVal ParentID As String, ByVal TemplateName As String)
'            MyBase.New(EnuElementType.HiddenEdit, "WEAlertBox", Page, ParentID, TemplateName)
'            Call Element_Open()
'        End Sub


'        Private Sub Element_Open() Handles Me.Open
'            MyBase.ElementInfo.ToolBoxCaption = My.Resources.text.LocalizableOpen._0071 '"Boîte d'alerte" 
'            MyBase.ElementInfo.VersionMajor = 1
'            MyBase.ElementInfo.VersionMinor = 0
'            MyBase.ElementInfo.GroupName = "NBGroupInteractivity"
'            MyBase.ElementInfo.ToolBoxIco = My.Resources.WEAlertBox
'            MyBase.ElementInfo.ToolBoxDescription = My.Resources.text.LocalizableOpen._0072 '"Afficher une boîte de dialogue sur une action au chargement de la page" & vbCrLf & "ou sur le clic d'un autre élément."
'        End Sub

'#Region "Render"

'        Private Sub MsgBox_PagePreRender() Handles Me.PagePreRender
'            If MyBase.Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Editor And Me.DesactivatePreview = True Then Exit Sub
'            MyBase.Page.ScriptManager.SetBodyEndBlocks("MsgBox" & MyBase.ID, "alert('" & Me.Text.GetValue(MyBase.Page.Culture) & "')")
'        End Sub

'        Private Sub Element_PageLoad() Handles Me.PagePreRender

'        End Sub

'#End Region

'        Private Sub Element_Save() Handles Me.Save

'        End Sub

'    End Class

'End Namespace



