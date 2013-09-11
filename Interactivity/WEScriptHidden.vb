Imports openElement.WebElement
Imports openElement.WebElement.Elements
Imports System.ComponentModel
Imports openElement.WebElement.Common

Namespace Elements.Interactivity


    <Serializable()> _
        Public Class WEScriptHidden
        Inherits ElementBase

        Private _ScriptBlock As ScriptBlock


#Region "Proprietes"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
         Ressource.localizable.LocalizableNameAtt("_N126"), _
         Ressource.localizable.LocalizableDescAtt("_D126"), _
         Editor(GetType(openElement.WebElement.Editors.UITypeScriptBlock), GetType(Drawing.Design.UITypeEditor)), _
         Attributes.PageUpdateMode(Attributes.PageUpdateMode.EnuUpdateMode.None)> _
         Public Property ScriptBlock() As ScriptBlock
            Get
                If _ScriptBlock Is Nothing Then
                    _ScriptBlock = New ScriptBlock(Me.ID, EnuScriptType.Javascript, EnuScriptPosition.Header)
                End If
                Return _ScriptBlock
            End Get
            Set(ByVal value As ScriptBlock)
                _ScriptBlock = value
            End Set
        End Property
#End Region

#Region "Constructeur"
        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.HiddenEdit, "WEScriptHidden", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0202 '"Bloc de code masqué" 
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupScript"
            info.ToolBoxIco = My.Resources.WEScriptHidden
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0203
            info.SortPropertyList.Add(New SortProperty("ScriptBlock", "Tools.png", My.Resources.text.LocalizableOpen._0206)) '"Configurer"
            info.AutoOpenProperty = "ScriptBlock"
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Me.ScriptBlock.UsersOrder = True

            MyBase.DisabledStyles = True
            MyBase.OnOpen()

        End Sub

#End Region


        Protected Overrides Sub OnPageBeforeRender(ByVal mode As Page.EnuTypeRenderMode)
            If mode <> Page.EnuTypeRenderMode.Editor Then Me.AddBlockScripts(Me.ScriptBlock)

            MyBase.OnPageBeforeRender(mode)
        End Sub

        ''' <summary>Used by Packs to update certain elements, for example Blocks of code (scripts) that may contain old IDs in their code, when IDs of elements are changed</summary>
        ''' <param name="OldToNewElemIDs">Pairs OldID-NewID</param>
        Public Overrides Sub OnListOfIDsUpdated(ByVal oldToNewElemIDs As Dictionary(Of String, String))
            If oldToNewElemIDs Is Nothing Then Exit Sub
            Dim code As String = ScriptBlock.Code.GetValue(Me.Page.Culture)
            If ScriptBlock Is Nothing OrElse String.IsNullOrEmpty(code) Then Exit Sub

            If String.IsNullOrEmpty(code) OrElse Not code.Contains("WE") Then Exit Sub

            ' replace each old ID by new ID
            For Each kvp As KeyValuePair(Of String, String) In oldToNewElemIDs
                code = code.Replace(kvp.Key, kvp.Value)
            Next

            ScriptBlock.Code.SetValue(code, Me.Page.Culture)

        End Sub



    End Class



End Namespace
