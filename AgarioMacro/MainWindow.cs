using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace AgarioMacro {
    public partial class MainWindow : Form {
        public MainWindow() {
            InitializeComponent();
		}


		private int getModuleWidth() {
			int result = p_Modules.Width - 8;

			if(p_Modules.VerticalScroll.Visible) {
				result -= SystemInformation.VerticalScrollBarWidth;
			}

			return result;
		}

		private void MainWindow_Load(object sender, EventArgs e) {
			btn_Stop.Enabled = false;
			//p_Modules.AutoScroll = true;
			p_Modules.FlowDirection = FlowDirection.TopDown;
			p_Modules.WrapContents = false;

			var keys = Program.moduleManager.getModules().Keys;

			int moduleWidth = getModuleWidth();

			foreach (String key in keys) {
				Debug.WriteLine("Adding panel from " + key);
				Program.moduleManager.getModule(key).getPanel().MinimumSize = new Size(moduleWidth, Module.moduleMinHeight);
				p_Modules.Controls.Add(Program.moduleManager.getModule(key).getPanel());
			}
		}

		private void P_Modules_Resize(object sender, EventArgs e) {
			int moduleWidth = getModuleWidth();
			var keys = Program.moduleManager.getModules().Keys;
			foreach (String key in keys) {
				Program.moduleManager.getModule(key).getPanel().MinimumSize = new Size(moduleWidth, Module.moduleMinHeight);
			}
		}

		private void MainWindow_FormClosed(object sender, FormClosedEventArgs e) {
			Program.exit();
		}

		private void Btn_Start_Click(object sender, EventArgs e) {
			btn_Start.Enabled = false;
			btn_Stop.Enabled = true;
			if (!Program.hook.Hooked) {
				Program.hook.hook();
			}
		}

		private void Btn_Stop_Click(object sender, EventArgs e) {
			btn_Stop.Enabled = false;
			btn_Start.Enabled = true;
			if (Program.hook.Hooked) {
				Program.hook.unhook();
			}
		}
	}
}
