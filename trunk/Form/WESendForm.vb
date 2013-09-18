Imports System.ComponentModel
Imports System.Drawing.Design

Imports openElement.DB.Packs
Imports openElement.WebElement
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Elements
Imports openElement.WebElement.ElementWECommon.Form.Forms

Imports WebElement.Elements.Form.Editors
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Form

    <Serializable> _
    Public Class WESendForm
        Inherits ElementBase
        Implements IDynPackElement

        #Region "Fields"

        ' to update when unpacking an element pack
        <ContainsLinks> _
        Private _Config As FrmWESendFormConfig.WESendFormConfig

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.HiddenEdit, "WESendForm", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        ''' <summary>Whether to add current URL params to the action link</summary>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N241"), _
        LocalizableDescAtt("_D241")> _
        Public Property AddURLParams() As Boolean
            Get
                Return Config.KeepURLParams
            End Get
            Set(ByVal value As Boolean)
                Config.KeepURLParams = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N153"), _
        LocalizableDescAtt("_D153"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        Editor(GetType(UITypeWESendFormConfig), GetType(UITypeEditor)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Config() As FrmWESendFormConfig.WESendFormConfig
            Get
                If _Config Is Nothing Then _Config = New FrmWESendFormConfig.WESendFormConfig
                Return _Config
            End Get
            Set(ByVal value As FrmWESendFormConfig.WESendFormConfig)
                _Config = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        ''' <summary>Called after unpacking an element pack</summary>
        Public Sub IDPOnAfterUnpack(ByVal pack As DBElementPack, Optional ByVal targetDS As PageDynStructure = Nothing) Implements IDynPackElement.IDPOnAfterUnpack
            If pack Is Nothing Then Exit Sub

            If pack.OldToNewElemID.Count > 0 Then
                ' update IDS of elements in Config, and remove old IDs with no update match
                Dim elemIDs As Dictionary(Of String, String) = Config.FormLinks.ElementsID
                Dim idsToChange As New List(Of String)

                ' find all element IDs to update:
                If elemIDs IsNot Nothing AndAlso elemIDs.Count > 0 Then
                    For Each elID As String In elemIDs.Keys
                        If String.IsNullOrEmpty(elID) Then Continue For
                        If pack.OldToNewElemID.ContainsKey(elID) Then idsToChange.Add(elID)
                    Next
                End If

                ' replace old IDs by new, keeping types:
                For Each oldID As String In idsToChange
                    Dim tp As String = elemIDs(oldID)
                    elemIDs.Remove(oldID)
                    Dim newID As String = pack.OldToNewElemID(oldID) : If String.IsNullOrEmpty(newID) Then Continue For
                    elemIDs(newID) = tp
                Next

                ' same for buttons Submit and Cancel:
                If Not String.IsNullOrEmpty(Config.FormLinks.ButtonSubmitID) Then
                    If pack.OldToNewElemID.ContainsKey(Config.FormLinks.ButtonSubmitID) Then Config.FormLinks.ButtonSubmitID = pack.OldToNewElemID(Config.FormLinks.ButtonSubmitID) _
                                                                                        Else Config.FormLinks.ButtonSubmitID = Nothing
                End If
                If Not String.IsNullOrEmpty(Config.FormLinks.ButtonCancelID) Then
                    If pack.OldToNewElemID.ContainsKey(Config.FormLinks.ButtonCancelID) Then Config.FormLinks.ButtonCancelID = pack.OldToNewElemID(Config.FormLinks.ButtonCancelID) _
                                                                                        Else Config.FormLinks.ButtonCancelID = Nothing
                End If
            End If
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0284
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupForm"
            info.ToolBoxIco = My.Resources.WESendForm
            info.ToolBoxDescription = LocalizableOpen._0285
            info.SortPropertyList.Add(New SortProperty("Config", "Tools.png", LocalizableOpen._0092))
            info.AutoOpenProperty = "Config"
            Return info
        End Function

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WESendForm.js", "WEFiles/Client/WESendForm.js")
            MyBase.AddSharedScripts(EnuSharedScript.jQueryForm)
            MyBase.OnInitExternalFiles()
        End Sub

        Protected Overrides Sub OnOpen()
            MyBase.OnOpen()
        End Sub

        #End Region 'Methods

    End Class

End Namespace

