Imports System.Drawing.Design
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors
Imports System.Web.UI
Imports openElement.Tools
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable
Imports openElement.WebElement
Imports openElement.WebElement.Elements
Imports System.ComponentModel
Imports openElement.WebElement.Common
Imports LocalizableCatAtt = WebElement.Ressource.localizable.LocalizableCatAtt
Imports LocalizableNameAtt = WebElement.Ressource.localizable.LocalizableNameAtt

Namespace Elements.Interactivity


    <Serializable()> _
    Public Class WECodeBlock
        Inherits ElementBase

        Private _CodeBlock As CodeBlock

        Private _ScriptBlock As ScriptBlock

        ' <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Edition), _
        ' LocalizableNameAtt("_N115"), _
        ' LocalizableDescAtt("_D115"), _
        'Editor(GetType(UITypeCodeBlock), GetType(UITypeEditor)), _
        'PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        'Public Property CodeBlock() As CodeBlock
        '     Get
        '         If _CodeBlock Is Nothing Then _CodeBlock = New CodeBlock
        '         Return _CodeBlock
        '     End Get
        '     Set(ByVal value As CodeBlock)
        '         _CodeBlock = value
        '     End Set
        ' End Property

        <LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
         LocalizableNameAtt("_N115"), _
         LocalizableDescAtt("_D115"), _
         Editor(GetType(UITypeScriptBlock), GetType(UITypeEditor)), _
         PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
         Public Property ScriptBlock() As ScriptBlock
            Get
                If _ScriptBlock Is Nothing Then
                    _ScriptBlock = New ScriptBlock(Me.ID, EnuScriptType.Html)
                    If _CodeBlock IsNot Nothing Then
                        _ScriptBlock.Code = _CodeBlock.Code
                        _ScriptBlock.Type = _CodeBlock.ScriptType
                        _CodeBlock = Nothing
                    End If
                End If
                Return _ScriptBlock
            End Get
            Set(ByVal value As ScriptBlock)
                _ScriptBlock = value
            End Set
        End Property

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WECodeBlock", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0126 '"Bloc de code" 
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupScript"
            info.ToolBoxIco = My.Resources.WECodeBlock
            info.ToolBoxDescription = LocalizableOpen._0311 'Ajouter du texte libre (script)
            info.AutoOpenProperty = "ScriptBlock"
            info.SortPropertyList.Add(New SortProperty("ScriptBlock", "Tools.png", LocalizableOpen._0206)) '"Configurer"
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            MyBase.DisabledStyles = False

            MyBase.OnOpen()
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)

            If Me.Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Editor Then

                MyBase.RenderBeginTag(writer, "line-height:0;")

                Dim cssWidth As String = "16px"
                Dim cssHeight As String = "16px"
                Select Case MyBase.TypeResize
                    Case EnuTypeResize.Both
                        cssWidth = "100%"
                        cssHeight = "100%"
                    Case EnuTypeResize.Width
                        cssWidth = "100%"
                    Case EnuTypeResize.Height
                        cssHeight = "100%"
                End Select

                writer.WriteBeginTag("div")
                writer.WriteAttribute("style", "width:" & cssWidth & ";height:" & cssHeight & ";background-image:url('" & String.Concat(Utils.EditorModCSSPath, "/images/Code.png") & "');background-repeat:no-repeat;background-position:center;")
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteEndTag("div")

            Else
                MyBase.RenderBeginTag(writer)

                If Me.Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Source Then
                    writer.WriteLine(WebElem.CreateScriptBlock(Me.ScriptBlock, Me.Page.Culture, -1, -1))
                Else
                    writer.WriteLine(Me.ScriptBlock.Code.GetValue(Me.Page.Culture))
                End If

            End If


            MyBase.RenderEndTag(writer)

        End Sub

        ''' <summary>Used by Packs to update certain elements, for example Blocks of code (scripts) that may contain old IDs in their code, when IDs of elements are changed</summary>
        ''' <param name="OldToNewElemIDs">Pairs OldID-NewID</param>
        Public Overrides Sub OnListOfIDsUpdated(ByVal oldToNewElemIDs As Dictionary(Of String, String))
            If oldToNewElemIDs Is Nothing Then Exit Sub
            Dim newCode As New Dictionary(Of String, String)
            Dim codeLSItems As Dictionary(Of String, String) = Me.ScriptBlock.Code.Items
            For Each culture In codeLSItems.Keys
                Dim code As String = codeLSItems(culture)
                If String.IsNullOrEmpty(code) OrElse Not code.Contains("WE") Then Continue For

                ' replace each old ID by new ID
                For Each kvp As KeyValuePair(Of String, String) In oldToNewElemIDs
                    code = code.Replace(kvp.Key, kvp.Value)
                Next
                newCode(culture) = code
            Next

            For Each culture In newCode.Keys
                codeLSItems(culture) = newCode(culture)
            Next
        End Sub



    End Class

End Namespace
