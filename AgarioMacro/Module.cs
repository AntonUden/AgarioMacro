using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace AgarioMacro {
    abstract class Module {
		public static int moduleMinHeight = 50;

		private Boolean enabled;
		protected FlowLayoutPanel panel;

		protected CheckBox enableCheckBox;
		protected Label enabledLabel;

		public void init() {
			panel = new FlowLayoutPanel();

			String nameNoSpace = this.getName().Replace(" ", "");

			panel.Name = "modulePanel_" + nameNoSpace;
			panel.BorderStyle = BorderStyle.FixedSingle;
			panel.FlowDirection = FlowDirection.LeftToRight;

			panel.AutoSize = true;

			panel.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left);


			Label nameLabel = new Label();

			nameLabel.Name = "moduleNameLabel_" + nameNoSpace;
			nameLabel.Margin = new Padding(7, 7, 7, 7);
			nameLabel.Text = this.getName();

			enableCheckBox = new CheckBox();
			enableCheckBox.Name = "cbx_enableModule_" + nameNoSpace;
			enableCheckBox.Text = "Enable";

			enableCheckBox.CheckedChanged += enableCheckBox_CheckedChanged;

			enabledLabel = new Label();
			enabledLabel.Name = "lbl_moduleEnabled_" + nameNoSpace;
			enabledLabel.Margin = new Padding(7, 7, 7, 7);
			updateEnabledLabel();



			panel.Controls.Add(nameLabel);
			panel.Controls.Add(enableCheckBox);
			panel.Controls.Add(enabledLabel);

			this.onLoad();
		}

		public void exit() {
			this.onExit();
		}

		protected void updateEnabledLabel() {
			enabledLabel.Text = (enabled ? "Enabled" : "Disabled");
			enabledLabel.ForeColor = (enabled ? Color.Green : Color.Red);
		}

		private void enableCheckBox_CheckedChanged(Object sender, System.EventArgs e) {
			if(((CheckBox)sender).Checked == this.enabled) {
				//Debug.WriteLine("checked == enabled");
				return;
			}

			setEnabled(((CheckBox)sender).Checked, false);
		}

		public Panel getPanel() {
			return panel;
		}

		public abstract String getName();

		public Boolean setEnabled(Boolean enabled) {
			return setEnabled(enabled, true);
		}

		public Boolean setEnabled(Boolean enabled, Boolean changeCheckbox) {
			if(enabled) {
				return enable(changeCheckbox);
			}
			return disable(changeCheckbox);
		}

		public Boolean enable() {
			return enable(true);
		}

		public Boolean enable(Boolean changeCheckbox) {
			if(enabled) {
				return false;
			}

			this.onEnable();
			Debug.WriteLine(this.getName() + " enabled");
			this.enabled = true;
			updateEnabledLabel();
			if (changeCheckbox) {
				this.enableCheckBox.Checked = true;
			}

			return true;
		}

		public Boolean disable() {
			return disable(true);
		}

		public Boolean disable(Boolean changeCheckbox) {
			if (!enabled) {
				return false;
			}

			this.onDisable();
			Debug.WriteLine(this.getName() + " disabled");
			this.enabled = false;
			updateEnabledLabel();
			if (changeCheckbox) {
				this.enableCheckBox.Checked = false;
			}

			return true;
		}

		public Boolean isEnabled() {
			return this.enabled;
		}

		protected virtual void onLoad() { }

		protected virtual void onExit() { }

		protected virtual void onEnable() {}

		protected virtual void onDisable() {}

		public virtual void onKeyDown(Keys key) { }

		public virtual void onKeyUp(Keys key) { }

	}
}