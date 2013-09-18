
Imports System.ComponentModel
Imports openElement.WebElement.Common
Imports openElement.Tools
Imports System.Web.UI
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Elements
Imports openElement.WebElement.StylesManager

Namespace WEElements.Standard


    <Serializable()> _
Public Class WETable
        Inherits ElementBase

        Private _NbRow As Integer
        Private _NbCol As Integer

        <ContainsLinks()> _
        Private _Table As WETableData
        Private _ActiveRow As Integer
        Private _ActiveCol As Integer
        Private _Informer As Boolean
        Private _NotEditable As Boolean

        <NonSerialized()> _
        Private _ConfigStylesZones As List(Of ConfigStylesZone)

#Region "Properties"
        ''' <summary>
        ''' number of line of the table
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
        Public Property NbRow() As Integer
            Get
                Return _NbRow
            End Get
            Set(ByVal value As Integer)
                _NbRow = value
            End Set
        End Property

        ''' <summary>
        ''' number of columns of the table
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
        Public Property NbCol() As Integer
            Get
                Return _NbCol
            End Get
            Set(ByVal value As Integer)
                _NbCol = value
            End Set
        End Property

        ''' <summary>
        ''' Data table
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
        Public Property Table() As WETableData
            Get
                If _Table Is Nothing Then _Table = New WETableData(NbRow, NbCol)
                Return _Table
            End Get
            Set(ByVal value As WETableData)
                _Table = value
            End Set
        End Property

        ''' <summary>
        ''' Property allowing the data saving of the user input in the editor
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
        Public Property Cell(ByVal row As Object, ByVal col As Object)
            Get
                Return (Table.GetLocalizableHtml(Integer.Parse(row), Integer.Parse(Col)))
            End Get
            Set(ByVal value)
                Table.SetValue(row, Col, value)
            End Set
        End Property

        ''' <summary>
        ''' display the line and the columns in editor mode
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.EditMode), _
       Ressource.localizable.LocalizableNameAtt("_N199"), _
       LocalizableDescAtt("_D199"), _
       PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
       Public Property Informer() As Boolean
            Get
                If MyBase.Page.RenderMode <> openElement.WebElement.Page.EnuTypeRenderMode.Editor Then Return False
                Return _Informer

            End Get
            Set(ByVal value As Boolean)
                _Informer = value
            End Set
        End Property

        <Browsable(False)> _
        Public Property ConfigStylesZones() As List(Of ConfigStylesZone)
            Get
                If _ConfigStylesZones Is Nothing Then _ConfigStylesZones = New List(Of ConfigStylesZone)
                Return _ConfigStylesZones
            End Get
            Set(ByVal value As List(Of ConfigStylesZone))
                _ConfigStylesZones = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.EditMode), _
        Ressource.localizable.LocalizableNameAtt("_N201"), _
        LocalizableDescAtt("_D201"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NotEditable() As Boolean
            Get
                Return _NotEditable
            End Get
            Set(ByVal value As Boolean)
                _NotEditable = value
            End Set
        End Property

        ''' <summary>
        ''' update the number of row of table
        ''' </summary>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N198"), _
        LocalizableDescAtt("_D198"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property ActNbRow() As Integer
            Get
                Return NbRow
            End Get
            Set(ByVal value As Integer)
                If value < 1 Then value = 1
                Call ChangeNbRow(value)
            End Set
        End Property

        ''' <summary>
        ''' update the number of columns of table
        ''' </summary>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N197"), _
        LocalizableDescAtt("_D197"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property ActNbCol() As Integer
            Get
                Return NbCol
            End Get
            Set(ByVal value As Integer)
                If value < 1 Then value = 1
                Call ChangeNbColumn(value)
            End Set
        End Property

#End Region


#Region "Builder required function"
       
        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WETable", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None

            NbCol = 2
            NbRow = 2
            Me.NumUpdate = 1
            InitStyleZone()

        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0336
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupStandard"
            info.ToolBoxIco = My.Resources.WETable
            info.ToolBoxDescription = LocalizableOpen._0337

            info.SortPropertyList.Add(New SortProperty("Action:ActAddRow", "row_add_after.png", LocalizableOpen._0338))
            info.SortPropertyList.Add(New SortProperty("Action:ActAddColumn", "column_add_after.png", LocalizableOpen._0339))
            info.SortPropertyList.Add(New SortProperty("Action:ActDeleteRow", "row_delete.png", LocalizableOpen._0340))
            info.SortPropertyList.Add(New SortProperty("Action:ActDeleteColumn", "column_delete.png", LocalizableOpen._0341))
            info.SortPropertyList.Add(New SortProperty("Action:ActInsertRow", "row_add.png", LocalizableOpen._0342))
            info.SortPropertyList.Add(New SortProperty("Action:ActInsertColumn", "column_add.png", LocalizableOpen._0343))
            info.SortPropertyList.Add(New SortProperty("Action:ActInsertCellStylesZone", "row_styles.png", LocalizableOpen._0398))

            Return info

        End Function

        Protected Overrides Sub OnOpen()

            MyBase.OnOpen(InitStyleZone, False)
        End Sub

        Protected Overrides Sub OnPageBeforeRender(ByVal mode As openElement.WebElement.Page.EnuTypeRenderMode)
            MyBase.UpdateConfigStylesZones(ConfigStylesZones, False)
            MyBase.OnPageBeforeRender(Mode)
        End Sub

#End Region

#Region " Style zones management"

        Private Function InitStyleZone() As List(Of ConfigStylesZone)

            ConfigStylesZones.Clear()
            ConfigStylesZones.Add(New ConfigStylesZone("TableMain", LocalizableOpen._0344, LocalizableOpen._0345))
            ConfigStylesZones.Add(New ConfigStylesZone("TableCell", LocalizableOpen._0346, LocalizableOpen._0347))

            For row As Integer = 0 To NbRow - 1

                ConfigStylesZones.Add(CreateRowStylesZones(row))

                For col As Integer = 0 To NbCol - 1
                    If row > 0 Then ConfigStylesZones.Add(CreateColStylesZones(col))
                    If Me.NumUpdate < 1 Then Call AddCellStyleZone(row, col)
                Next

            Next
            Return ConfigStylesZones

        End Function

        Private Function CreateRowStylesZones(ByVal row As Integer) As ConfigStylesZone

            Dim configSZ = New ConfigStylesZone(CreateRowStyleName(row), String.Format(LocalizableOpen._0350, row), LocalizableOpen._0351)
            With configSZ
                .Level = StylesZone.EnuLevel.Advenced
                .NoSaveInModel = True
            End With

            Return configSZ

        End Function

        Private Function CreateColStylesZones(ByVal col As Integer) As ConfigStylesZone

            Dim configSZ = New ConfigStylesZone(CreateColumnStyleName(Col), String.Format(LocalizableOpen._0352, Col), LocalizableOpen._0353)
            With configSZ
                .Level = StylesZone.EnuLevel.Advenced
                .NoSaveInModel = True
            End With

            Return configSZ

        End Function

        Private Function CreateCelStylesZones(ByVal row As Integer, ByVal col As Integer) As ConfigStylesZone

            Dim configSZ = New ConfigStylesZone(CreateCellStyleName(row, Col), String.Format(LocalizableOpen._0348, Col, row), LocalizableOpen._0349)
            With configSZ
                .Level = StylesZone.EnuLevel.AdvencedSelectable
                .NoSaveInModel = True
            End With

            Return configSZ

        End Function

        ''' <summary>
        ''' Adding of a style zone for a row
        ''' </summary>
        ''' <param name="row"></param>
        ''' <remarks></remarks>
        Private Sub AddRowStyleZone(ByVal row As Integer)
            ConfigStylesZones.Add(CreateRowStylesZones(row))
            If Me.NumUpdate < 1 Then
                For col As Integer = 0 To NbCol - 1
                    Call AddCellStyleZone(row, col)
                Next
            End If
        End Sub

        ''' <summary>
        ''' Delete a row style zone
        ''' </summary>
        ''' <param name="row"></param>
        ''' <remarks></remarks>
        Private Sub DeleteRowStyleZone(ByVal row As Integer)
            Dim zoneIndex As Integer = FindIndexStyleZone(CreateRowStyleName(row))
            If zoneIndex > -1 Then ConfigStylesZones.RemoveAt(zoneIndex)
            If Me.NumUpdate < 1 Then
                For col As Integer = 0 To NbCol - 1
                    Call DeleteCellStyleZone(row, col)
                Next
            End If
        End Sub

        ''' <summary>
        ''' Adding of a style zone for a columns
        ''' </summary>
        ''' <param name="col"></param>
        ''' <remarks></remarks>
        Private Sub AddColumnStyleZone(ByVal col As Integer)
            ConfigStylesZones.Add(CreateColStylesZones(col))
            If Me.NumUpdate < 1 Then
                For row As Integer = 0 To NbRow - 1
                    Call AddCellStyleZone(row, col)
                Next
            End If
        End Sub

        ''' <summary>
        ''' Delete a columns style zone
        ''' </summary>
        Private Sub DeleteColumnStyleZone(ByVal col As Integer)
            Dim zoneIndex As Integer = FindIndexStyleZone(CreateColumnStyleName(col))
            If zoneIndex > -1 Then ConfigStylesZones.RemoveAt(zoneIndex)
            If Me.NumUpdate < 1 Then
                For row As Integer = 0 To NbRow - 1
                    Call DeleteCellStyleZone(row, col)
                Next
            End If
        End Sub

        ''' <summary>
        ''' Adding of a style zone for a cell
        ''' </summary>
        ''' <param name="row"></param>
        ''' <param name="col"></param>
        ''' <remarks></remarks>
        Private Sub AddCellStyleZone(ByVal row As Integer, ByVal col As Integer)
            Dim configStylesZone As ConfigStylesZone = CreateCelStylesZones(row, col)
            ConfigStylesZones.Add(configStylesZone)
        End Sub

        ''' <summary>
        ''' delete a cell style zone
        ''' </summary>
        ''' <param name="row"></param>
        ''' <param name="col"></param>
        ''' <remarks></remarks>
        Private Sub DeleteCellStyleZone(ByVal row As Integer, ByVal col As Integer)
            Dim zoneIndex As Integer = FindIndexStyleZone(CreateCellStyleName(row, col))
            If zoneIndex > -1 Then ConfigStylesZones.RemoveAt(zoneIndex)
        End Sub

        ''' <summary>
        ''' seach the index for a styleZone
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function FindIndexStyleZone(ByVal name As String) As Integer
            Dim index As Integer = -1
            For Each item In ConfigStylesZones
                If item.Name.Equals(name) Then Exit For
                index += 1
            Next
            Return index
        End Function


#End Region


        Protected Overrides Function OnShortActionUpdateMode(ByVal actionName As String) As PageUpdateMode.EnuUpdateMode
            Return PageUpdateMode.EnuUpdateMode.Element
        End Function


        Protected Overrides Sub OnShortAction(ByVal actionName As String)

            Select Case actionName
                Case "ActInsertCellStylesZone"
                    If Not GetActiveCell() OrElse _ActiveRow < 0 Then OEMsgBox(LocalizableOpen._0354, MsgBoxType.Info) : Exit Sub '"Veuillez selectionner une cellule du tableau."
                    Call AddCellStyleZone(_ActiveRow, _ActiveCol)
                    WebElem.ChangeSelectedStylesZone(Me.ID, CreateCellStyleName(_ActiveRow, _ActiveCol))
                Case "ActAddRow"
                    AddRow()
                Case "ActAddColumn"
                    AddColumn()
                Case "ActDeleteRow"
                    If Not GetActiveCell() OrElse _ActiveRow < 0 Then OEMsgBox(LocalizableOpen._0354, MsgBoxType.Info) : Exit Sub '"Veuillez selectionner une cellule du tableau."
                    Dim answer As MsgBoxReturn = OEMsgBox(String.Format(LocalizableOpen._0355, _ActiveRow), MsgBoxType.Question_YesNo) 'Souhaitez vous supprimer la ligne {0}
                    If answer <> MsgBoxReturn.Yes Then Exit Sub
                    DeleteRow(_ActiveRow)
                Case "ActDeleteRow"
                    If Not GetActiveCell() OrElse _ActiveRow < 0 Then OEMsgBox(LocalizableOpen._0354, MsgBoxType.Info) : Exit Sub '"Veuillez selectionner une cellule du tableau."
                    Dim answer As MsgBoxReturn = OEMsgBox(String.Format(LocalizableOpen._0355, _ActiveRow), MsgBoxType.Question_YesNo) 'Souhaitez vous supprimer la ligne {0}
                    If answer <> MsgBoxReturn.Yes Then Exit Sub
                    DeleteRow(_ActiveRow)
                Case "ActDeleteColumn"
                    If Not GetActiveCell() OrElse _ActiveRow < 0 Then OEMsgBox(LocalizableOpen._0354, MsgBoxType.Info) : Exit Sub '"Veuillez selectionner une cellule du tableau."
                    Dim answer As MsgBoxReturn = OEMsgBox(String.Format(LocalizableOpen._0356, _ActiveCol), MsgBoxType.Question_YesNo) 'Souhaitez vous supprimer la colonne {0}
                    If answer <> MsgBoxReturn.Yes Then Exit Sub
                    Call DeleteColumn(_ActiveCol)
                Case "ActInsertRow"
                    If Not GetActiveCell() OrElse _ActiveRow < 0 Then OEMsgBox(LocalizableOpen._0354, MsgBoxType.Info) : Exit Sub '"Veuillez selectionner une cellule du tableau."
                    Call InsertRow(_ActiveRow)
                    Me.StylesSkin.BaseDiv.FindStyles(StylesZone.EnuStyleState.Normal).Height.Auto = True
                Case "ActInsertColumn"
                    If Not GetActiveCell() OrElse _ActiveRow < 0 Then OEMsgBox(LocalizableOpen._0354, MsgBoxType.Info) : Exit Sub '"Veuillez selectionner une cellule du tableau."
                    Call InsertColumn(_ActiveCol)
                    Me.StylesSkin.BaseDiv.FindStyles(StylesZone.EnuStyleState.Normal).Width.Auto = True
            End Select

        End Sub


#Region "Data Management"
 
        Private Sub AddRow()
            Table.AddRow(NbCol)
            Call AddRowStyleZone(NbRow)
            NbRow += 1
            Me.StylesSkin.BaseDiv.FindStyles(StylesZone.EnuStyleState.Normal).Height.Auto = True
        End Sub

        Private Sub AddColumn()

            Table.AddColumn()
            Call AddColumnStyleZone(NbCol)

            NbCol += 1
            Me.StylesSkin.BaseDiv.FindStyles(StylesZone.EnuStyleState.Normal).Width.Auto = True
        End Sub

        Private Sub DeleteRow(ByVal delRow As Integer)

            'data update
            Table.DeleteRow(delRow)

            'Style zone update
            Call DeleteRowStyleZone(NbRow - 1)
            For row = delRow To NbRow - 1
                Me.StylesSkin.StylesZoneRename(Me.CreateRowStyleName(row + 1), Me.CreateRowStyleName(row), True)
                If Me.NumUpdate < 1 Then
                    For col = 0 To NbCol - 1
                        Me.StylesSkin.StylesZoneRename(Me.CreateCellStyleName(row + 1, col), Me.CreateCellStyleName(row, col), True)
                    Next
                End If
            Next

            NbRow -= 1
            Me.StylesSkin.BaseDiv.FindStyles(StylesZone.EnuStyleState.Normal).Height.Auto = True

        End Sub

        Private Sub DeleteColumn(ByVal delCol As Integer)

            'data update
            Table.DeleteColumn(delCol)

            'Style zone update
            Call DeleteColumnStyleZone(NbCol - 1)
            If Me.NumUpdate < 1 Then
                For row = 0 To NbRow - 1
                    For col = delCol To NbCol - 1

                        Me.StylesSkin.StylesZoneRename(Me.CreateColumnStyleName(col + 1), Me.CreateColumnStyleName(col), True)
                        Me.StylesSkin.StylesZoneRename(Me.CreateCellStyleName(row, col + 1), Me.CreateCellStyleName(row, col), True)

                    Next
                Next
            Else
                For col = delCol To NbCol - 1
                    Me.StylesSkin.StylesZoneRename(Me.CreateColumnStyleName(col + 1), Me.CreateColumnStyleName(col), True)
                Next
            End If

            NbCol -= 1 'no use the property (this delete an another row)
            Me.StylesSkin.BaseDiv.FindStyles(StylesZone.EnuStyleState.Normal).Width.Auto = True
        End Sub

        Private Sub InsertRow(ByVal insRow As Integer)
            'Style zone update
            Call AddRowStyleZone(NbRow)
            For row = NbRow To insRow + 1 Step -1
                Me.StylesSkin.StylesZoneRename(Me.CreateRowStyleName(row), Me.CreateRowStyleName(row + 1), True)
                If Me.NumUpdate < 1 Then
                    For col = 0 To NbCol - 1
                        Me.StylesSkin.StylesZoneRename(Me.CreateCellStyleName(row, col), Me.CreateCellStyleName(row + 1, col), True)
                    Next
                End If
            Next

            Table.InsertRow(insRow, NbCol)
            NbRow += 1
        End Sub

        Private Sub InsertColumn(ByVal insCol As Integer)

            If Not GetActiveCell() OrElse _ActiveCol < 0 Then Exit Sub

            'Style zone update
            Call AddColumnStyleZone(NbCol)
            For row = 0 To NbRow - 1
                For col = NbCol To insCol + 1 Step -1
                    Me.StylesSkin.StylesZoneRename(Me.CreateColumnStyleName(col), Me.CreateColumnStyleName(col + 1), True)
                    If Me.NumUpdate < 1 Then Me.StylesSkin.StylesZoneRename(Me.CreateCellStyleName(row, col), Me.CreateCellStyleName(row, col + 1), True)
                Next
            Next
            Table.InsertColumn(insCol)
            NbCol += 1

        End Sub

        ''' <summary>
        ''' row number update
        ''' </summary>
        ''' <param name="newNbRow"></param>
        ''' <remarks></remarks>
        Private Sub ChangeNbRow(ByVal newNbRow As Integer)
            If NbRow = NewNbRow Then Exit Sub

            If NbRow < NewNbRow Then
                For row = NbRow To newNbRow - 1
                    AddRow()
                Next
            Else
                For row As Integer = NbRow - 1 To NewNbRow Step -1
                    DeleteRow(row)
                Next
            End If
            NbRow = NewNbRow
        End Sub

        ''' <summary>
        ''' columns number update
        ''' </summary>
        ''' <param name="NewNbCol"></param>
        ''' <remarks></remarks>
        Private Sub ChangeNbColumn(ByVal newNbCol As Integer)
            If NbCol = newNbCol Then Exit Sub

            If NbCol < newNbCol Then
                For col = NbCol To newNbCol - 1
                    AddColumn()
                Next
            Else
                For col As Integer = NbCol - 1 To newNbCol Step -1
                    DeleteColumn(col)
                Next
            End If
            NbCol = newNbCol
        End Sub
#End Region

        ''' <summary>
        ''' create stylezone name  
        ''' </summary>
        ''' <param name="Row"></param>
        ''' <param name="Col"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CreateCellStyleName(ByVal row As Integer, ByVal col As Integer) As String
            Return String.Concat("Cell-", row, "-", col)
        End Function

        ''' <summary>
        ''' create a stylezone of row (and cell of row)
        ''' </summary>
        ''' <param name="row"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CreateRowStyleName(ByVal row As Integer) As String
            Return String.Concat("Row_", row)
        End Function

        ''' <summary>
        ''' create a stylezone of column (and cell of column)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CreateColumnStyleName(ByVal col As Integer) As String
            Return String.Concat("Column_", col)
        End Function

        ''' <summary>
        ''' get the cell number of active row
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetActiveCell() As Boolean
            _ActiveRow = -1
            _ActiveCol = -1
            Dim activeZoneName As String = MyBase.GetCurrentPropertyName
            If Not activeZoneName.StartsWith("Cell(") Then Return False
            activeZoneName = activeZoneName.Substring(5, activeZoneName.Length - 6)
            Dim spl() As String = activeZoneName.Split(",")
            If spl.Length <> 2 Then Return False
            Me._ActiveRow = Convert.ToInt32(spl(0))
            Me._ActiveCol = Convert.ToInt32(spl(1))
            Return True
        End Function


#Region "Render"

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)


            MyBase.RenderBeginTag(writer)

            writer.WriteBeginTag("table")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("TableMain"))
            writer.Write(HtmlTextWriter.TagRightChar)

            If Me.Informer Then
                writer.WriteBeginTag("tr")
                writer.WriteAttribute("style", "border:1px dotted LightGray; background-color:#EEEEEE; font-family :Comic Sans MS ; font-size :10px; color :#666666; height:16px; text-align:center;")
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteLine()

                writer.WriteBeginTag("td")
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.Write("")
                writer.WriteEndTag("td")

                For col As Integer = 0 To NbCol - 1
                    writer.WriteBeginTag("td")
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.Write(col)
                    writer.WriteEndTag("td")
                Next
                writer.WriteEndTag("tr")
            End If

            writer.WriteLine()
            writer.Indent += 1
            For row As Integer = 0 To NbRow - 1
                writer.WriteBeginTag("tr")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass(CreateRowStyleName(row)))
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteLine()
                If Me.Informer Then
                    writer.WriteBeginTag("td")
                    writer.WriteAttribute("style", "border:1px dotted LightGray; background-color:#EEEEEE; font-family :Comic Sans MS ; font-size :10px; color :#666666;width:16px;text-align:center;")
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.Write(row)
                    writer.WriteEndTag("td")
                End If
                For col As Integer = 0 To NbCol - 1
                    writer.WriteBeginTag("td")
                    Dim classList As String() = {CreateCellStyleName(row, col), "TableCell", Me.CreateColumnStyleName(col)}
                    writer.WriteAttribute("class", String.Concat(MyBase.GetStyleZoneClass(classList), " ", "WEEdTableCell"))
                    writer.Write(HtmlTextWriter.TagRightChar)
                    If NotEditable Then
                        writer.WriteHtmlBlock(Me, "Cell(" & row & "," & col & ")")
                    Else
                        writer.WriteHtmlBlockEdit(Me, "Cell(" & row & "," & col & ")", True, , HtmlWriter.BlockType.MaxBox)
                    End If
                    writer.WriteEndTag("td")
                    writer.WriteLine()
                Next

                writer.WriteEndTag("tr")
                writer.Indent -= 1
                writer.WriteLine()
            Next

            writer.WriteEndTag("table")


            MyBase.RenderEndTag(writer)


        End Sub

#End Region

    End Class

#Region "Mains config  class"


    ''' <summary>
    ''' Main config class of  WETable : row 
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class WETableData
        <ContainsLinks()> _
        Private _Rows As List(Of WETableColumn)


        Public Property Rows() As List(Of WETableColumn)
            Get
                If _Rows Is Nothing Then _Rows = New List(Of WETableColumn)
                Return _Rows
            End Get
            Set(ByVal value As List(Of WETableColumn))
                _Rows = value
            End Set
        End Property


        Public Sub New(ByVal nbRow As Integer, ByVal nbCol As Integer)
            For i = 0 To nbRow - 1
                Rows.Add(New WETableColumn(nbCol))
            Next
        End Sub

        Public Sub AddRow(ByVal nbCol As Integer)
            Rows.Add(New WETableColumn(nbCol))
        End Sub

        Public Sub AddColumn()
            For row As Integer = 0 To Rows.Count - 1
                Rows(row).AddColumn()
            Next
        End Sub

        ''' <summary>
        ''' delete a row at index
        ''' </summary>
        ''' <param name="row"></param>
        ''' <remarks></remarks>
        Public Sub DeleteRow(ByVal row As Integer)
            Rows(row).DisposeColumn()
            Rows.RemoveAt(row)
        End Sub

        ''' <summary>
        ''' delete a column at index for all rows
        ''' </summary>
        ''' <param name="col"></param>
        ''' <remarks></remarks>
        Public Sub DeleteColumn(ByVal col As Integer)
            For row As Integer = 0 To Rows.Count - 1
                Rows(row).DisposeColumn(col)
            Next
        End Sub

        Public Sub InsertRow(ByVal indexRow As Integer, ByVal nbCol As Integer)
            Rows.Insert(indexRow + 1, New WETableColumn(nbCol))
        End Sub

        Public Sub InsertColumn(ByVal indexCol As Integer)
            For row = 0 To Rows.Count - 1
                Rows(row).InsertColumn(indexCol + 1)
            Next
        End Sub

        ''' <summary>
        ''' get a cell value
        ''' </summary>
        ''' <param name="row">index of row</param>
        ''' <param name="Col">index of column</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetLocalizableHtml(ByVal row As Integer, ByVal col As Integer) As LocalizableHtml
            Return Rows(row).GetLocalizableHtml(col)
        End Function

        ''' <summary>
        ''' set a cell value
        ''' </summary>
        ''' <param name="row">index of row</param>
        ''' <param name="col">index of column</param>
        ''' <param name="value">value to set</param>
        ''' <remarks></remarks>
        Public Sub SetValue(ByVal row As Integer, ByVal col As Integer, ByVal value As LocalizableHtml)
            Rows(row).SetValue(col, value)
        End Sub
    End Class

    ''' <summary>
    '''  Main config class of  WETable : column
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class WETableColumn
        <ContainsLinks()> _
        Private _Columns As List(Of WETableCell)

        Public Property Columns() As List(Of WETableCell)
            Get
                If _Columns Is Nothing Then _Columns = New List(Of WETableCell)
                Return _Columns
            End Get
            Set(ByVal value As List(Of WETableCell))
                _Columns = value
            End Set
        End Property


        Public Sub New(ByVal nbCol As Integer)
            For i = 0 To nbCol - 1
                Call AddColumn()
            Next
        End Sub


        Public Sub AddColumn()
            Columns.Add(New WETableCell)
        End Sub

        ''' <summary>
        ''' Delete a column at the index
        ''' </summary>
        ''' <param name="col"></param>
        ''' <remarks></remarks>
        Public Sub DisposeColumn(ByVal col As Integer)
            Columns(col).Dispose()
            Columns.RemoveAt(col)
        End Sub

        ''' <summary>
        ''' delete all column
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub DisposeColumn()
            For col = 0 To Columns.Count - 1
                Columns(col).Dispose()
            Next
            Me.Columns.Clear()
            Columns = Nothing
        End Sub


        Public Sub InsertColumn(ByVal indexCol As Integer)
            Columns.Insert(IndexCol, New WETableCell)
        End Sub

        ''' <summary>
        ''' get a row value by a column index
        ''' </summary>
        ''' <param name="col"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetLocalizableHtml(ByVal col As Integer) As LocalizableHtml
            Return Columns(Col).LocalHTML
        End Function

        ''' <summary>
        ''' set a value at cell by column index
        ''' </summary>
        ''' <param name="col"></param>
        ''' <param name="value"></param>
        ''' <remarks></remarks>
        Public Sub SetValue(ByVal col As Integer, ByVal value As LocalizableHtml)
            Columns(col).LocalHTML = Value
        End Sub

    End Class


    ''' <summary>
    ''' Main config class of  WETable : cell
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class WETableCell
        Implements IDisposable
        Private _LocalHTML As LocalizableHtml

        ''' <summary>
        ''' Value of cell
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LocalHTML() As LocalizableHtml
            Get
                If _LocalHTML Is Nothing Then _LocalHTML = New LocalizableHtml
                Return _LocalHTML
            End Get
            Set(ByVal value As LocalizableHtml)
                _LocalHTML = value
            End Set
        End Property

        Public Sub New()

        End Sub

#Region "Implement"
        Public Sub Dispose() Implements IDisposable.Dispose
            Me.LocalHTML.Dispose()
            Me.LocalHTML = Nothing
        End Sub
#End Region


    End Class


#End Region



End Namespace