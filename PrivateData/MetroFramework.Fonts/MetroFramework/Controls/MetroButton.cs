using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Drawing;

namespace MetroFramework.Controls
{
	// Token: 0x0200001A RID: 26
	[Designer("MetroFramework.Design.MetroButtonDesigner, MetroFramework.Design, Version=1.2.0.3, Culture=neutral, PublicKeyToken=5f91a84759bf584a")]
	[ToolboxBitmap(typeof(Button))]
	[DefaultEvent("Click")]
	public class MetroButton : MetroButtonBase
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000BF RID: 191 RVA: 0x000042B8 File Offset: 0x000024B8
		// (set) Token: 0x060000C0 RID: 192 RVA: 0x000042C0 File Offset: 0x000024C0
		[DefaultValue(false)]
		public bool Highlight
		{
			get
			{
				return this.highlight;
			}
			set
			{
				this.highlight = value;
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000042C9 File Offset: 0x000024C9
		public MetroButton()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x000042E0 File Offset: 0x000024E0
		protected override void OnPaint(PaintEventArgs e)
		{
			Color color;
			Color color2;
			Color foreColor;
			if (this.isHovered && !this.isPressed && base.Enabled)
			{
				color = MetroPaint.BackColor.Button.Hover(base.Theme);
				color2 = MetroPaint.BorderColor.Button.Hover(base.Theme);
				foreColor = MetroPaint.ForeColor.Button.Hover(base.Theme);
			}
			else if (this.isHovered && this.isPressed && base.Enabled)
			{
				color = MetroPaint.BackColor.Button.Press(base.Theme);
				color2 = MetroPaint.BorderColor.Button.Press(base.Theme);
				foreColor = MetroPaint.ForeColor.Button.Press(base.Theme);
			}
			else if (!base.Enabled)
			{
				color = MetroPaint.BackColor.Button.Disabled(base.Theme);
				color2 = MetroPaint.BorderColor.Button.Disabled(base.Theme);
				foreColor = MetroPaint.ForeColor.Button.Disabled(base.Theme);
			}
			else
			{
				color = MetroPaint.BackColor.Button.Normal(base.Theme);
				color2 = MetroPaint.BorderColor.Button.Normal(base.Theme);
				foreColor = MetroPaint.ForeColor.Button.Normal(base.Theme);
			}
			e.Graphics.Clear(color);
			using (Pen pen = new Pen(color2))
			{
				Rectangle rect = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
				e.Graphics.DrawRectangle(pen, rect);
			}
			if (this.Highlight && !this.isHovered && !this.isPressed && base.Enabled)
			{
				using (Pen stylePen = MetroPaint.GetStylePen(base.Style))
				{
					Rectangle rect2 = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
					e.Graphics.DrawRectangle(stylePen, rect2);
					rect2 = new Rectangle(1, 1, base.Width - 3, base.Height - 3);
					e.Graphics.DrawRectangle(stylePen, rect2);
				}
			}
			TextRenderer.DrawText(e.Graphics, this.Text, MetroFonts.Button, base.ClientRectangle, foreColor, color, MetroPaint.GetTextFormatFlags(this.TextAlign));
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x000044D8 File Offset: 0x000026D8
		protected override void OnGotFocus(EventArgs e)
		{
			this.isFocused = true;
			base.Invalidate();
			base.OnGotFocus(e);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000044EE File Offset: 0x000026EE
		protected override void OnLostFocus(EventArgs e)
		{
			this.isFocused = false;
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnLostFocus(e);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00004512 File Offset: 0x00002712
		protected override void OnEnter(EventArgs e)
		{
			this.isFocused = true;
			base.Invalidate();
			base.OnEnter(e);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00004528 File Offset: 0x00002728
		protected override void OnLeave(EventArgs e)
		{
			this.isFocused = false;
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnLeave(e);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000454C File Offset: 0x0000274C
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				this.isHovered = true;
				this.isPressed = true;
				base.Invalidate();
			}
			base.OnKeyDown(e);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00004573 File Offset: 0x00002773
		protected override void OnKeyUp(KeyEventArgs e)
		{
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnKeyUp(e);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00004590 File Offset: 0x00002790
		protected override void OnMouseEnter(EventArgs e)
		{
			this.isHovered = true;
			base.Invalidate();
			base.OnMouseEnter(e);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000045A6 File Offset: 0x000027A6
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.isPressed = true;
				base.Invalidate();
			}
			base.OnMouseDown(e);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000045C9 File Offset: 0x000027C9
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.isPressed = false;
			base.Invalidate();
			base.OnMouseUp(e);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000045DF File Offset: 0x000027DF
		protected override void OnMouseLeave(EventArgs e)
		{
			this.isHovered = false;
			base.Invalidate();
			base.OnMouseLeave(e);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000045F5 File Offset: 0x000027F5
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			base.Invalidate();
		}

		// Token: 0x04000037 RID: 55
		private bool highlight;

		// Token: 0x04000038 RID: 56
		private bool isHovered;

		// Token: 0x04000039 RID: 57
		private bool isPressed;

		// Token: 0x0400003A RID: 58
		private bool isFocused;
	}
}
