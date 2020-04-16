<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class usrTrayectoria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(usrTrayectoria))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ChartController1 = New Steema.TeeChart.ChartController()
        Me.TChart1 = New Steema.TeeChart.TChart()
        Me.Line3 = New Steema.TeeChart.Styles.Line()
        Me.Points1 = New Steema.TeeChart.Styles.Points()
        Me.Line1 = New Steema.TeeChart.Styles.Line()
        Me.Points2 = New Steema.TeeChart.Styles.Points()
        Me.Line2 = New Steema.TeeChart.Styles.Line()
        Me.Points3 = New Steema.TeeChart.Styles.Points()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ChartController1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TChart1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(878, 514)
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
        Me.ChartController1.Size = New System.Drawing.Size(878, 30)
        Me.ChartController1.TabIndex = 0
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
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Bottom.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TChart1.Axes.Bottom.Labels.Font.Size = 9
        Me.TChart1.Axes.Bottom.Labels.Font.SizeFloat = 9.0!
        '
        '
        '
        Me.TChart1.Axes.Bottom.Title.Caption = "Desplazamiento (m)"
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Bottom.Title.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TChart1.Axes.Bottom.Title.Font.Size = 11
        Me.TChart1.Axes.Bottom.Title.Font.SizeFloat = 11.0!
        Me.TChart1.Axes.Bottom.Title.Lines = New String() {"Desplazamiento (m)"}
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Left.Grid.DrawEvery = 2
        Me.TChart1.Axes.Left.Grid.Visible = False
        Me.TChart1.Axes.Left.Inverted = True
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
        Me.TChart1.Axes.Left.Title.Caption = "Profundidad (mV)"
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Left.Title.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TChart1.Axes.Left.Title.Font.Size = 11
        Me.TChart1.Axes.Left.Title.Font.SizeFloat = 11.0!
        Me.TChart1.Axes.Left.Title.Lines = New String() {"Profundidad (mV)"}
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Right.Grid.Visible = False
        Me.TChart1.Axes.Right.Increment = 0.2R
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
        Me.TChart1.Axes.Right.Title.Caption = "Angulos (°), Severidad (°/m)"
        '
        '
        '
        Me.TChart1.Axes.Right.Title.Font.Size = 11
        Me.TChart1.Axes.Right.Title.Font.SizeFloat = 11.0!
        Me.TChart1.Axes.Right.Title.Lines = New String() {"Angulos (°), Severidad (°/m)"}
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
        Me.TChart1.Axes.Top.Labels.MultiLine = True
        '
        '
        '
        Me.TChart1.Axes.Top.Title.Caption = "Desplazamiento m"
        Me.TChart1.Axes.Top.Title.Lines = New String() {"Desplazamiento m"}
        Me.TChart1.CurrentTheme = Steema.TeeChart.ThemeType.Report
        Me.TChart1.Cursor = System.Windows.Forms.Cursors.Default
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
        Me.TChart1.Legend.DrawBehind = False
        '
        '
        '
        '
        '
        '
        Me.TChart1.Legend.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
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
        Me.TChart1.Series.Add(Me.Line3)
        Me.TChart1.Series.Add(Me.Points1)
        Me.TChart1.Series.Add(Me.Line1)
        Me.TChart1.Series.Add(Me.Points2)
        Me.TChart1.Series.Add(Me.Line2)
        Me.TChart1.Series.Add(Me.Points3)
        Me.TChart1.Size = New System.Drawing.Size(872, 478)
        Me.TChart1.TabIndex = 1
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
        'Line3
        '
        '
        '
        '
        Me.Line3.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Line3.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Line3.ColorEach = False
        '
        '
        '
        Me.Line3.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(43, Byte), Integer))
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
        Me.Line3.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        '
        '
        Me.Line3.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Line3.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Line3.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos"), System.Drawing.PointF)
        Me.Line3.Marks.TailParams.Margin = 0!
        Me.Line3.Marks.TailParams.PointerHeight = 5.0R
        Me.Line3.Marks.TailParams.PointerWidth = 8.0R
        Me.Line3.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Line3.OriginalCursor = System.Windows.Forms.Cursors.Default
        '
        '
        '
        Me.Line3.Pointer.SizeDouble = 0R
        Me.Line3.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Line3.Title = "Registro completo"
        Me.Line3.UseExtendedNumRange = False
        '
        '
        '
        Me.Line3.XValues.DataMember = "X"
        Me.Line3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        '
        '
        Me.Line3.YValues.DataMember = "Y"
        '
        'Points1
        '
        Me.Points1.Color = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.Points1.ColorEach = False
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
        Me.Points1.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos1"), System.Drawing.PointF)
        Me.Points1.Marks.TailParams.Margin = 0!
        Me.Points1.Marks.TailParams.PointerHeight = 5.0R
        Me.Points1.Marks.TailParams.PointerWidth = 8.0R
        Me.Points1.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Points1.OriginalCursor = System.Windows.Forms.Cursors.Default
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
        Me.Points1.Title = "Registro simplicado"
        Me.Points1.UseExtendedNumRange = False
        '
        '
        '
        Me.Points1.XValues.DataMember = "X"
        Me.Points1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        '
        '
        Me.Points1.YValues.DataMember = "Y"
        '
        'Line1
        '
        '
        '
        '
        Me.Line1.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Line1.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Line1.ColorEach = False
        '
        '
        '
        Me.Line1.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(128, Byte), Integer))
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
        Me.Line1.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(0, Byte), Integer))
        '
        '
        '
        Me.Line1.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Line1.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Line1.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos2"), System.Drawing.PointF)
        Me.Line1.Marks.TailParams.Margin = 0!
        Me.Line1.Marks.TailParams.PointerHeight = 5.0R
        Me.Line1.Marks.TailParams.PointerWidth = 8.0R
        Me.Line1.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Line1.OriginalCursor = System.Windows.Forms.Cursors.Default
        '
        '
        '
        Me.Line1.Pointer.SizeDouble = 0R
        Me.Line1.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Line1.Title = "Angulo registro completo"
        Me.Line1.UseExtendedNumRange = False
        Me.Line1.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Right
        '
        '
        '
        Me.Line1.XValues.DataMember = "X"
        Me.Line1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        '
        '
        Me.Line1.YValues.DataMember = "Y"
        '
        'Points2
        '
        Me.Points2.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Points2.ColorEach = False
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
        Me.Points2.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(0, Byte), Integer))
        '
        '
        '
        Me.Points2.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Points2.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Points2.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos3"), System.Drawing.PointF)
        Me.Points2.Marks.TailParams.Margin = 0!
        Me.Points2.Marks.TailParams.PointerHeight = 5.0R
        Me.Points2.Marks.TailParams.PointerWidth = 8.0R
        Me.Points2.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Points2.OriginalCursor = System.Windows.Forms.Cursors.Default
        '
        '
        '
        '
        '
        '
        Me.Points2.Pointer.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
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
        Me.Points2.Title = "Angulo registro simplificado"
        Me.Points2.UseExtendedNumRange = False
        Me.Points2.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Right
        '
        '
        '
        Me.Points2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        'Line2
        '
        '
        '
        '
        Me.Line2.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line2.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line2.ColorEach = False
        '
        '
        '
        Me.Line2.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(62, Byte), Integer))
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
        Me.Line2.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(230, Byte), Integer))
        '
        '
        '
        Me.Line2.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Line2.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Line2.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos4"), System.Drawing.PointF)
        Me.Line2.Marks.TailParams.Margin = 0!
        Me.Line2.Marks.TailParams.PointerHeight = 5.0R
        Me.Line2.Marks.TailParams.PointerWidth = 8.0R
        Me.Line2.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Line2.OriginalCursor = System.Windows.Forms.Cursors.Default
        '
        '
        '
        Me.Line2.Pointer.SizeDouble = 0R
        Me.Line2.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Line2.Title = "Severidad registro completo"
        Me.Line2.UseExtendedNumRange = False
        Me.Line2.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Right
        '
        '
        '
        Me.Line2.XValues.DataMember = "X"
        Me.Line2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        '
        '
        Me.Line2.YValues.DataMember = "Y"
        '
        'Points3
        '
        Me.Points3.Color = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Points3.ColorEach = False
        '
        '
        '
        Me.Points3.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(62, Byte), Integer))
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
        Me.Points3.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(173, Byte), Integer))
        '
        '
        '
        Me.Points3.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Points3.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Points3.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos5"), System.Drawing.PointF)
        Me.Points3.Marks.TailParams.Margin = 0!
        Me.Points3.Marks.TailParams.PointerHeight = 5.0R
        Me.Points3.Marks.TailParams.PointerWidth = 8.0R
        Me.Points3.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Points3.OriginalCursor = System.Windows.Forms.Cursors.Default
        '
        '
        '
        '
        '
        '
        Me.Points3.Pointer.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        '
        '
        '
        Me.Points3.Pointer.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(104, Byte), Integer))
        '
        '
        '
        Me.Points3.Pointer.Pen.Visible = False
        Me.Points3.Pointer.SizeDouble = 0R
        Me.Points3.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Points3.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Circle
        Me.Points3.Title = "Severidad de registro simplicado"
        Me.Points3.UseExtendedNumRange = False
        Me.Points3.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Right
        '
        '
        '
        Me.Points3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        'usrTrayectoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "usrTrayectoria"
        Me.Size = New System.Drawing.Size(878, 514)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As Forms.TableLayoutPanel
    Friend WithEvents ChartController1 As Steema.TeeChart.ChartController
    Friend WithEvents TChart1 As Steema.TeeChart.TChart
    Friend WithEvents Line1 As Steema.TeeChart.Styles.Line
    Friend WithEvents Line2 As Steema.TeeChart.Styles.Line
    Friend WithEvents Line3 As Steema.TeeChart.Styles.Line
    Friend WithEvents Points1 As Steema.TeeChart.Styles.Points
    Friend WithEvents Points2 As Steema.TeeChart.Styles.Points
    Friend WithEvents Points3 As Steema.TeeChart.Styles.Points
End Class
