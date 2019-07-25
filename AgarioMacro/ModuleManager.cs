using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Input;

namespace AgarioMacro {
	class ModuleManager {
		private Dictionary<String, Module> modules;

		public ModuleManager() {
			modules = new Dictionary<string, Module>();
		}

		public Type[] GetTypesInNamespace(Assembly assembly, string nameSpace) {
			return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
		}

		public Dictionary<String, Module> getModules() {
			return modules;
		}

		public Module getModule(String name) {
			Module module;
			if (modules.TryGetValue(name, out module)) {
				return module;
			}
			return null;
		}

		public void onExit() {
			disableAll();
			var keys = Program.moduleManager.getModules().Keys;
			foreach (String key in keys) {
				getModule(key).exit();
			}
		}

		public void handleKeyPress(Keys key, KeyPressType type) {
			if(key == Keys.W || key == Keys.Space) {
				return;
			}

			var keys = Program.moduleManager.getModules().Keys;
			foreach (String k in keys) {
				Module module = getModule(k);

				if(module.isEnabled()) {
					if(type == KeyPressType.KEY_DOWN) {
						module.onKeyDown(key);
						continue;
					}

					module.onKeyUp(key);
				}
			}
		}

		public void disableAll() {
			var keys = Program.moduleManager.getModules().Keys;
			foreach (String key in keys) {
				getModule(key).disable(true);
			}
		}

		public void loadModules(String nameSpace) {
			Type[] typeList = GetTypesInNamespace(Assembly.GetExecutingAssembly(), nameSpace);

			foreach (Type t in typeList) {
				if(typeof(Module).IsAssignableFrom(t)) {
					Module module = (Module) Activator.CreateInstance(t);
					Debug.WriteLine("Found " + module.getName());

					if (modules.ContainsKey(module.getName())) {
						Debug.WriteLine(module.getName() + " is already loaded");
					} else {
						Debug.WriteLine("Loading " + module.getName());
						try {
							module.init();
							modules.Add(module.getName(), module);
						} catch(Exception e) {
							Debug.WriteLine("Failed to load " + module.getName());
							Debug.WriteLine(e.ToString());
						}
					}
				} else {
					Debug.WriteLine("Ignore " + t.ToString());
				}
			}
		}
	}
}