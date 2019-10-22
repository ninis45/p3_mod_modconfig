<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class usrAforo
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(usrAforo))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ChartController1 = New Steema.TeeChart.ChartController()
        Me.TChart1 = New Steema.TeeChart.TChart()
        Me.Axis1 = New Steema.TeeChart.Axis(Me.components)
        Me.Axis2 = New Steema.TeeChart.Axis(Me.components)
        Me.Axis3 = New Steema.TeeChart.Axis(Me.components)
        Me.Axis4 = New Steema.TeeChart.Axis(Me.components)
        Me.Axis5 = New Steema.TeeChart.Axis(Me.components)
        Me.Points1 = New Steema.TeeChart.Styles.Points()
        Me.Points2 = New Steema.TeeChart.Styles.Points()
        Me.Points3 = New Steema.TeeChart.Styles.Points()
        Me.Points4 = New Steema.TeeChart.Styles.Points()
        Me.Points5 = New Steema.TeeChart.Styles.Points()
        Me.Line1 = New Steema.TeeChart.Styles.Line()
        Me.MovingAverage1 = New Steema.TeeChart.Functions.MovingAverage()
        Me.Line2 = New Steema.TeeChart.Styles.Line()
        Me.MovingAverage2 = New Steema.TeeChart.Functions.MovingAverage()
        Me.Line3 = New Steema.TeeChart.Styles.Line()
        Me.MovingAverage3 = New Steema.TeeChart.Functions.MovingAverage()
        Me.Line4 = New Steema.TeeChart.Styles.Line()
        Me.MovingAverage4 = New Steema.TeeChart.Functions.MovingAverage()
        Me.Line5 = New Steema.TeeChart.Styles.Line()
        Me.MovingAverage5 = New Steema.TeeChart.Functions.MovingAverage()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ChartController1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TChart1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(643, 438)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ChartController1
        '
        Me.ChartController1.ButtonSize = Steema.TeeChart.ControllerButtonSize.x16
        Me.ChartController1.Chart = Me.TChart1
        Me.ChartController1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartController1.LabelValues = True
        Me.ChartController1.Location = New System.Drawing.Point(0, 0)
        Me.ChartController1.Name = "ChartController1"
        Me.ChartController1.Size = New System.Drawing.Size(643, 30)
        Me.ChartController1.TabIndex = 2
        Me.ChartController1.Text = "ChartController1"
        '
        'TChart1
        '
        '
        '
        '
        Me.TChart1.Aspect.ColorPaletteIndex = 20
        Me.TChart1.Aspect.View3D = False
        '
        '
        '
        Me.TChart1.Axes.Automatic = True
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Bottom.Grid.DrawEvery = 2
        '
        '
        '
        Me.TChart1.Axes.Bottom.Labels.DateTimeFormat = "dd/MM/yyyy"
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Bottom.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TChart1.Axes.Bottom.Labels.Font.Size = 6
        Me.TChart1.Axes.Bottom.Labels.Font.SizeFloat = 6.0!
        '
        '
        '
        Me.TChart1.Axes.Bottom.Title.Caption = "Fecha"
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Bottom.Title.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TChart1.Axes.Bottom.Title.Lines = New String() {"Fecha"}
        Me.TChart1.Axes.Custom.Add(Me.Axis1)
        Me.TChart1.Axes.Custom.Add(Me.Axis2)
        Me.TChart1.Axes.Custom.Add(Me.Axis3)
        Me.TChart1.Axes.Custom.Add(Me.Axis4)
        Me.TChart1.Axes.Custom.Add(Me.Axis5)
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Left.Grid.DrawEvery = 2
        '
        '
        '
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Left.Labels.Font.Brush.Color = System.Drawing.Color.Gray
        Me.TChart1.Axes.Left.Labels.Font.Size = 9
        Me.TChart1.Axes.Left.Labels.Font.SizeFloat = 9.0!
        '
        '
        '
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Left.Title.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TChart1.Axes.Left.Title.Font.Size = 11
        Me.TChart1.Axes.Left.Title.Font.SizeFloat = 11.0!
        Me.TChart1.Axes.Left.Visible = False
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Right.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TChart1.Axes.Right.Labels.Font.Size = 9
        Me.TChart1.Axes.Right.Labels.Font.SizeFloat = 9.0!
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Top.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TChart1.Axes.Top.Labels.Font.Size = 9
        Me.TChart1.Axes.Top.Labels.Font.SizeFloat = 9.0!
        Me.TChart1.CurrentTheme = Steema.TeeChart.ThemeType.Report
        Me.TChart1.Dock = System.Windows.Forms.DockStyle.Fill
        '
        '
        '
        '
        '
        '
        '
        '
        '
        Me.TChart1.Header.Font.Brush.Color = System.Drawing.Color.Gray
        Me.TChart1.Header.Font.Size = 12
        Me.TChart1.Header.Font.SizeFloat = 12.0!
        Me.TChart1.Header.Visible = False
        '
        '
        '
        Me.TChart1.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom
        Me.TChart1.Legend.CheckBoxes = True
        '
        '
        '
        '
        '
        '
        Me.TChart1.Legend.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TChart1.Legend.Font.Size = 6
        Me.TChart1.Legend.Font.SizeFloat = 6.0!
        '
        '
        '
        Me.TChart1.Legend.Shadow.Visible = False
        Me.TChart1.Location = New System.Drawing.Point(3, 33)
        Me.TChart1.Name = "TChart1"
        '
        '
        '
        '
        '
        '
        Me.TChart1.Panel.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.TChart1.Panel.Brush.Gradient.Visible = False
        Me.TChart1.Panel.MarginLeft = 20.0R
        Me.TChart1.Panel.MarginRight = 16.0R
        Me.TChart1.Series.Add(Me.Points1)
        Me.TChart1.Series.Add(Me.Points2)
        Me.TChart1.Series.Add(Me.Points3)
        Me.TChart1.Series.Add(Me.Points4)
        Me.TChart1.Series.Add(Me.Points5)
        Me.TChart1.Series.Add(Me.Line1)
        Me.TChart1.Series.Add(Me.Line2)
        Me.TChart1.Series.Add(Me.Line3)
        Me.TChart1.Series.Add(Me.Line4)
        Me.TChart1.Series.Add(Me.Line5)
        Me.TChart1.Size = New System.Drawing.Size(637, 402)
        Me.TChart1.TabIndex = 3
        '
        '
        '
        '
        '
        '
        '
        '
        '
        Me.TChart1.Walls.Back.Brush.Visible = False
        Me.TChart1.Walls.Back.Visible = False
        '
        'Axis1
        '
        '
        '
        '
        Me.Axis1.Grid.Visible = False
        Me.Axis1.Horizontal = False
        '
        '
        '
        Me.Axis1.Labels.CustomSize = 19
        Me.Axis1.OtherSide = False
        '
        '
        '
        Me.Axis1.Title.Angle = 90
        Me.Axis1.Title.Caption = "PRODLIQ"
        Me.Axis1.Title.Lines = New String() {"PRODLIQ"}
        '
        'Axis2
        '
        '
        '
        '
        Me.Axis2.Grid.Visible = False
        Me.Axis2.Horizontal = False
        '
        '
        '
        Me.Axis2.Labels.CustomSize = 20
        Me.Axis2.OtherSide = False
        Me.Axis2.RelativePosition = -10.0R
        '
        '
        '
        Me.Axis2.Title.Angle = 90
        Me.Axis2.Title.Caption = "PRODGASFORM"
        Me.Axis2.Title.Lines = New String() {"PRODGASFORM"}
        '
        'Axis3
        '
        '
        '
        '
        Me.Axis3.Grid.Visible = False
        Me.Axis3.Horizontal = False
        '
        '
        '
        Me.Axis3.Labels.CustomSize = 21
        Me.Axis3.OtherSide = True
        Me.Axis3.RelativePosition = -1.0R
        '
        '
        '
        Me.Axis3.Title.Angle = 90
        Me.Axis3.Title.Caption = "VOLGASINY"
        Me.Axis3.Title.Lines = New String() {"VOLGASINY"}
        Me.Axis3.ZPosition = 0R
        '
        'Axis4
        '
        '
        '
        '
        Me.Axis4.Grid.Visible = False
        Me.Axis4.Horizontal = False
        '
        '
        '
        Me.Axis4.Labels.CustomSize = 21
        Me.Axis4.OtherSide = True
        Me.Axis4.RelativePosition = -12.0R
        '
        '
        '
        Me.Axis4.Title.Angle = 90
        Me.Axis4.Title.Caption = "FRACAGUA"
        Me.Axis4.Title.Lines = New String() {"FRACAGUA"}
        Me.Axis4.ZPosition = 0R
        '
        'Axis5
        '
        '
        '
        '
        Me.Axis5.Grid.Visible = False
        Me.Axis5.Horizontal = False
        '
        '
        '
        Me.Axis5.Labels.CustomSize = 17
        Me.Axis5.OtherSide = False
        Me.Axis5.RelativePosition = -22.0R
        '
        '
        '
        Me.Axis5.Title.Angle = 90
        Me.Axis5.Title.Caption = "TEMP"
        Me.Axis5.Title.Lines = New String() {"TEMP"}
        '
        'Points1
        '
        Me.Points1.Color = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.Points1.ColorEach = False
        Me.Points1.CustomVertAxis = Me.Axis1
        '
        '
        '
        Me.Points1.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(128, Byte), Integer))
        '
        '
        '
        Me.Points1.Marks.ArrowLength = 10
        '
        '
        '
        Me.Points1.Marks.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Points1.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Points1.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Points1.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Points1.Marks.Brush.Gradient.UseMiddle = True
        '
        '
        '
        '
        '
        '
        Me.Points1.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        '
        '
        '
        Me.Points1.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(193, Byte), Integer))
        '
        '
        '
        Me.Points1.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Points1.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Points1.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos"), System.Drawing.PointF)
        Me.Points1.Marks.TailParams.Margin = 0!
        Me.Points1.Marks.TailParams.PointerHeight = 5.0R
        Me.Points1.Marks.TailParams.PointerWidth = 8.0R
        Me.Points1.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Points1.OriginalCursor = Nothing
        '
        '
        '
        '
        '
        '
        Me.Points1.Pointer.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(214, Byte), Integer))
        '
        '
        '
        Me.Points1.Pointer.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(214, Byte), Integer))
        '
        '
        '
        Me.Points1.Pointer.Pen.Visible = False
        Me.Points1.Pointer.SizeDouble = 0R
        Me.Points1.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Points1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Circle
        Me.Points1.Title = "PRODLIQ"
        Me.Points1.UseExtendedNumRange = False
        Me.Points1.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Custom
        '
        '
        '
        Me.Points1.XValues.DataMember = "X"
        Me.Points1.XValues.DateTime = True
        Me.Points1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        '
        '
        Me.Points1.YValues.DataMember = "Y"
        '
        'Points2
        '
        Me.Points2.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Points2.ColorEach = False
        Me.Points2.CustomVertAxis = Me.Axis2
        '
        '
        '
        Me.Points2.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(62, Byte), Integer))
        '
        '
        '
        Me.Points2.Marks.ArrowLength = 10
        '
        '
        '
        Me.Points2.Marks.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Points2.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Points2.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Points2.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Points2.Marks.Brush.Gradient.UseMiddle = True
        '
        '
        '
        '
        '
        '
        Me.Points2.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        '
        '
        '
        Me.Points2.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        '
        '
        Me.Points2.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Points2.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Points2.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos1"), System.Drawing.PointF)
        Me.Points2.Marks.TailParams.Margin = 0!
        Me.Points2.Marks.TailParams.PointerHeight = 5.0R
        Me.Points2.Marks.TailParams.PointerWidth = 8.0R
        Me.Points2.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Points2.OriginalCursor = Nothing
        '
        '
        '
        '
        '
        '
        Me.Points2.Pointer.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(104, Byte), Integer))
        '
        '
        '
        Me.Points2.Pointer.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(104, Byte), Integer))
        '
        '
        '
        Me.Points2.Pointer.Pen.Visible = False
        Me.Points2.Pointer.SizeDouble = 0R
        Me.Points2.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Points2.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Circle
        Me.Points2.Title = "PRODGASFORM"
        Me.Points2.UseExtendedNumRange = False
        Me.Points2.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Custom
        '
        '
        '
        Me.Points2.XValues.DataMember = "X"
        Me.Points2.XValues.DateTime = True
        Me.Points2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        '
        '
        Me.Points2.YValues.DataMember = "Y"
        '
        'Points3
        '
        Me.Points3.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Points3.ColorEach = False
        Me.Points3.CustomVertAxis = Me.Axis3
        '
        '
        '
        Me.Points3.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        '
        '
        Me.Points3.Marks.ArrowLength = 10
        '
        '
        '
        Me.Points3.Marks.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Points3.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Points3.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Points3.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Points3.Marks.Brush.Gradient.UseMiddle = True
        '
        '
        '
        '
        '
        '
        Me.Points3.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        '
        '
        '
        Me.Points3.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        '
        '
        Me.Points3.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Points3.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Points3.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos2"), System.Drawing.PointF)
        Me.Points3.Marks.TailParams.Margin = 0!
        Me.Points3.Marks.TailParams.PointerHeight = 5.0R
        Me.Points3.Marks.TailParams.PointerWidth = 8.0R
        Me.Points3.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Points3.OriginalCursor = Nothing
        '
        '
        '
        '
        '
        '
        Me.Points3.Pointer.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(71, Byte), Integer))
        '
        '
        '
        Me.Points3.Pointer.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(71, Byte), Integer))
        '
        '
        '
        Me.Points3.Pointer.Pen.Visible = False
        Me.Points3.Pointer.SizeDouble = 0R
        Me.Points3.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Points3.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Circle
        Me.Points3.Title = "VOLGASINY"
        Me.Points3.UseExtendedNumRange = False
        Me.Points3.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Custom
        '
        '
        '
        Me.Points3.XValues.DataMember = "X"
        Me.Points3.XValues.DateTime = True
        Me.Points3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        '
        '
        Me.Points3.YValues.DataMember = "Y"
        '
        'Points4
        '
        Me.Points4.Color = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.Points4.ColorEach = False
        Me.Points4.CustomVertAxis = Me.Axis4
        '
        '
        '
        Me.Points4.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(121, Byte), Integer), CType(CType(131, Byte), Integer))
        '
        '
        '
        Me.Points4.Marks.ArrowLength = 10
        '
        '
        '
        Me.Points4.Marks.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Points4.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Points4.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Points4.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Points4.Marks.Brush.Gradient.UseMiddle = True
        '
        '
        '
        '
        '
        '
        Me.Points4.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        '
        '
        '
        Me.Points4.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(197, Byte), Integer))
        '
        '
        '
        Me.Points4.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Points4.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Points4.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos3"), System.Drawing.PointF)
        Me.Points4.Marks.TailParams.Margin = 0!
        Me.Points4.Marks.TailParams.PointerHeight = 5.0R
        Me.Points4.Marks.TailParams.PointerWidth = 8.0R
        Me.Points4.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Points4.OriginalCursor = Nothing
        '
        '
        '
        '
        '
        '
        Me.Points4.Pointer.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(219, Byte), Integer))
        '
        '
        '
        Me.Points4.Pointer.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(219, Byte), Integer))
        '
        '
        '
        Me.Points4.Pointer.Pen.Visible = False
        Me.Points4.Pointer.SizeDouble = 0R
        Me.Points4.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Points4.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Circle
        Me.Points4.Title = "FRACAGUA"
        Me.Points4.UseExtendedNumRange = False
        Me.Points4.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Custom
        '
        '
        '
        Me.Points4.XValues.DataMember = "X"
        Me.Points4.XValues.DateTime = True
        Me.Points4.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        '
        '
        Me.Points4.YValues.DataMember = "Y"
        '
        'Points5
        '
        Me.Points5.Color = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.Points5.ColorEach = False
        Me.Points5.CustomVertAxis = Me.Axis5
        '
        '
        '
        Me.Points5.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(95, Byte), Integer))
        '
        '
        '
        Me.Points5.Marks.ArrowLength = 10
        '
        '
        '
        Me.Points5.Marks.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Points5.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Points5.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Points5.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Points5.Marks.Brush.Gradient.UseMiddle = True
        '
        '
        '
        '
        '
        '
        Me.Points5.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        '
        '
        '
        Me.Points5.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(142, Byte), Integer))
        '
        '
        '
        Me.Points5.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Points5.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Points5.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos4"), System.Drawing.PointF)
        Me.Points5.Marks.TailParams.Margin = 0!
        Me.Points5.Marks.TailParams.PointerHeight = 5.0R
        Me.Points5.Marks.TailParams.PointerWidth = 8.0R
        Me.Points5.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Points5.OriginalCursor = Nothing
        '
        '
        '
        '
        '
        '
        Me.Points5.Pointer.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(158, Byte), Integer))
        '
        '
        '
        Me.Points5.Pointer.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(158, Byte), Integer))
        '
        '
        '
        Me.Points5.Pointer.Pen.Visible = False
        Me.Points5.Pointer.SizeDouble = 0R
        Me.Points5.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Points5.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Circle
        Me.Points5.Title = "TEMP"
        Me.Points5.UseExtendedNumRange = False
        Me.Points5.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Custom
        '
        '
        '
        Me.Points5.XValues.DataMember = "X"
        Me.Points5.XValues.DateTime = True
        Me.Points5.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        '
        '
        Me.Points5.YValues.DataMember = "Y"
        '
        'Line1
        '
        '
        '
        '
        Me.Line1.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line1.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line1.ColorEach = False
        Me.Line1.CustomVertAxis = Me.Axis1
        Me.Line1.DataSource = Me.Points1
        Me.Line1.Function = Me.MovingAverage1
        '
        '
        '
        Me.Line1.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(90, Byte), Integer))
        '
        '
        '
        '
        '
        '
        Me.Line1.Marks.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Line1.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line1.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line1.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Line1.Marks.Brush.Gradient.UseMiddle = True
        '
        '
        '
        '
        '
        '
        Me.Line1.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        '
        '
        '
        Me.Line1.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(135, Byte), Integer))
        '
        '
        '
        Me.Line1.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Line1.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Line1.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos5"), System.Drawing.PointF)
        Me.Line1.Marks.TailParams.Margin = 0!
        Me.Line1.Marks.TailParams.PointerHeight = 5.0R
        Me.Line1.Marks.TailParams.PointerWidth = 8.0R
        Me.Line1.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Line1.OriginalCursor = Nothing
        '
        '
        '
        Me.Line1.Pointer.SizeDouble = 0R
        Me.Line1.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Line1.Title = "Media PRODLIQ"
        Me.Line1.UseExtendedNumRange = False
        Me.Line1.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Custom
        '
        '
        '
        Me.Line1.XValues.DateTime = True
        Me.Line1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        '
        '
        Me.Line1.YValues.DataMember = "Y"
        '
        'MovingAverage1
        '
        Me.MovingAverage1.Period = 2.0R
        '
        'Line2
        '
        '
        '
        '
        Me.Line2.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line2.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line2.ColorEach = False
        Me.Line2.DataSource = Me.Points2
        Me.Line2.Function = Me.MovingAverage2
        '
        '
        '
        Me.Line2.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(39, Byte), Integer))
        '
        '
        '
        '
        '
        '
        Me.Line2.Marks.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Line2.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line2.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line2.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Line2.Marks.Brush.Gradient.UseMiddle = True
        '
        '
        '
        '
        '
        '
        Me.Line2.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        '
        '
        '
        Me.Line2.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(58, Byte), Integer))
        '
        '
        '
        Me.Line2.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Line2.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Line2.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos6"), System.Drawing.PointF)
        Me.Line2.Marks.TailParams.Margin = 0!
        Me.Line2.Marks.TailParams.PointerHeight = 5.0R
        Me.Line2.Marks.TailParams.PointerWidth = 8.0R
        Me.Line2.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Line2.OriginalCursor = Nothing
        '
        '
        '
        Me.Line2.Pointer.SizeDouble = 0R
        Me.Line2.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Line2.Title = "Media PRODGASFORM"
        Me.Line2.UseExtendedNumRange = False
        '
        '
        '
        Me.Line2.XValues.DateTime = True
        Me.Line2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        '
        '
        Me.Line2.YValues.DataMember = "Y"
        '
        'MovingAverage2
        '
        Me.MovingAverage2.Period = 2.0R
        '
        'Line3
        '
        '
        '
        '
        Me.Line3.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Line3.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Line3.ColorEach = False
        Me.Line3.DataSource = Me.Points3
        Me.Line3.Function = Me.MovingAverage3
        '
        '
        '
        Me.Line3.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(86, Byte), Integer))
        '
        '
        '
        '
        '
        '
        Me.Line3.Marks.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Line3.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line3.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line3.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Line3.Marks.Brush.Gradient.UseMiddle = True
        '
        '
        '
        '
        '
        '
        Me.Line3.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        '
        '
        '
        Me.Line3.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(130, Byte), Integer))
        '
        '
        '
        Me.Line3.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Line3.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Line3.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos7"), System.Drawing.PointF)
        Me.Line3.Marks.TailParams.Margin = 0!
        Me.Line3.Marks.TailParams.PointerHeight = 5.0R
        Me.Line3.Marks.TailParams.PointerWidth = 8.0R
        Me.Line3.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Line3.OriginalCursor = Nothing
        '
        '
        '
        Me.Line3.Pointer.SizeDouble = 0R
        Me.Line3.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Line3.Title = "Media VOLGASINY"
        Me.Line3.UseExtendedNumRange = False
        '
        '
        '
        Me.Line3.XValues.DateTime = True
        Me.Line3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        '
        '
        Me.Line3.YValues.DataMember = "Y"
        '
        'MovingAverage3
        '
        Me.MovingAverage3.Period = 2.0R
        '
        'Line4
        '
        '
        '
        '
        Me.Line4.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(144, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Line4.Color = System.Drawing.Color.FromArgb(CType(CType(144, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Line4.ColorEach = False
        Me.Line4.DataSource = Me.Points4
        Me.Line4.Function = Me.MovingAverage4
        '
        '
        '
        Me.Line4.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(86, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(125, Byte), Integer))
        '
        '
        '
        '
        '
        '
        Me.Line4.Marks.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Line4.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line4.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line4.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Line4.Marks.Brush.Gradient.UseMiddle = True
        '
        '
        '
        '
        '
        '
        Me.Line4.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        '
        '
        '
        Me.Line4.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(188, Byte), Integer))
        '
        '
        '
        Me.Line4.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Line4.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Line4.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos8"), System.Drawing.PointF)
        Me.Line4.Marks.TailParams.Margin = 0!
        Me.Line4.Marks.TailParams.PointerHeight = 5.0R
        Me.Line4.Marks.TailParams.PointerWidth = 8.0R
        Me.Line4.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Line4.OriginalCursor = Nothing
        '
        '
        '
        Me.Line4.Pointer.SizeDouble = 0R
        Me.Line4.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Line4.Title = "Media FRACAGUA"
        Me.Line4.UseExtendedNumRange = False
        '
        '
        '
        Me.Line4.XValues.DateTime = True
        Me.Line4.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        '
        '
        Me.Line4.YValues.DataMember = "Y"
        '
        'MovingAverage4
        '
        Me.MovingAverage4.Period = 2.0R
        '
        'Line5
        '
        '
        '
        '
        Me.Line5.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line5.Color = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line5.ColorEach = False
        Me.Line5.DataSource = Me.Points5
        Me.Line5.Function = Me.MovingAverage5
        '
        '
        '
        Me.Line5.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        '
        '
        '
        '
        '
        '
        Me.Line5.Marks.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Line5.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line5.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line5.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Line5.Marks.Brush.Gradient.UseMiddle = True
        '
        '
        '
        '
        '
        '
        Me.Line5.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        '
        '
        '
        Me.Line5.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(147, Byte), Integer))
        '
        '
        '
        Me.Line5.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Line5.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Line5.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos9"), System.Drawing.PointF)
        Me.Line5.Marks.TailParams.Margin = 0!
        Me.Line5.Marks.TailParams.PointerHeight = 5.0R
        Me.Line5.Marks.TailParams.PointerWidth = 8.0R
        Me.Line5.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Line5.OriginalCursor = Nothing
        '
        '
        '
        Me.Line5.Pointer.SizeDouble = 0R
        Me.Line5.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Line5.Title = "Media TEMP"
        Me.Line5.UseExtendedNumRange = False
        '
        '
        '
        Me.Line5.XValues.DateTime = True
        Me.Line5.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        '
        '
        Me.Line5.YValues.DataMember = "Y"
        '
        'MovingAverage5
        '
        Me.MovingAverage5.Period = 2.0R
        '
        'usrAforo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "usrAforo"
        Me.Size = New System.Drawing.Size(643, 438)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As Forms.TableLayoutPanel
    Friend WithEvents ChartController1 As Steema.TeeChart.ChartController
    Friend WithEvents TChart1 As Steema.TeeChart.TChart
    Friend WithEvents Points1 As Steema.TeeChart.Styles.Points
    Friend WithEvents Points2 As Steema.TeeChart.Styles.Points
    Friend WithEvents Points3 As Steema.TeeChart.Styles.Points
    Friend WithEvents Points4 As Steema.TeeChart.Styles.Points
    Friend WithEvents Points5 As Steema.TeeChart.Styles.Points
    Friend WithEvents Axis1 As Steema.TeeChart.Axis
    Friend WithEvents Axis2 As Steema.TeeChart.Axis
    Friend WithEvents Axis3 As Steema.TeeChart.Axis
    Friend WithEvents Axis4 As Steema.TeeChart.Axis
    Friend WithEvents Axis5 As Steema.TeeChart.Axis
    Friend WithEvents Line1 As Steema.TeeChart.Styles.Line
    Friend WithEvents MovingAverage1 As Steema.TeeChart.Functions.MovingAverage
    Friend WithEvents Line2 As Steema.TeeChart.Styles.Line
    Friend WithEvents MovingAverage2 As Steema.TeeChart.Functions.MovingAverage
    Friend WithEvents Line3 As Steema.TeeChart.Styles.Line
    Friend WithEvents MovingAverage3 As Steema.TeeChart.Functions.MovingAverage
    Friend WithEvents Line4 As Steema.TeeChart.Styles.Line
    Friend WithEvents MovingAverage4 As Steema.TeeChart.Functions.MovingAverage
    Friend WithEvents Line5 As Steema.TeeChart.Styles.Line
    Friend WithEvents MovingAverage5 As Steema.TeeChart.Functions.MovingAverage
End Class
