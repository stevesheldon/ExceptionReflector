using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using ExceptionReflector.Properties;

namespace ExceptionReflector
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void loadAssemblyLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filePath = GetFilePath();
            EnumerateAssembly(filePath);
        }

        private string GetFilePath()
        {
            var openFileDialong = new OpenFileDialog();

            openFileDialong.Title = Resources.SelectAssemblyLabel;
            openFileDialong.Filter = Resources.SelectAssemblyFilter;
            openFileDialong.FilterIndex = 0;

            if (openFileDialong.ShowDialog(this) == DialogResult.OK)
            {
                this.loadAssemblyLinkLabel.Text = openFileDialong.FileName;
            }

            return openFileDialong.FileName;
        }

        private void EnumerateAssembly(string filePath)
        {
            var assemblyEnumerator = new AssemblyEnumerator(filePath);

            foreach (var currentNameSpace in assemblyEnumerator.NameSpaces)
            {
                if (!string.IsNullOrEmpty(currentNameSpace))
                {
                    var namespaceTreeNode = new TreeNode(currentNameSpace);

                    bool hasClasses = false;

                    foreach (var classType in assemblyEnumerator.GetClasses(currentNameSpace))
                    {                        
                        bool hasMethods = false;
                        var classTreeNode = new TreeNode(classType.Name);

                        foreach (var method in assemblyEnumerator.GetMethodds(classType))
                        {
                            if (!method.IsGenericMethod)
                            {
                                var methodBase = method.GetMethodBase();
                                if (methodBase != null)
                                {
                                    var methodTreeNode = new TreeNode(method.GetFriendlyName());
                                    methodTreeNode.Tag = methodBase;

                                    bool hasExceptions;

                                    try
                                    {
                                        hasExceptions = method.HasAnyExceptions();
                                    }
                                    catch (ArgumentException)
                                    {
                                        hasExceptions = false;
                                    }

                                    methodTreeNode.ForeColor = hasExceptions ? Color.Black : Color.DarkGray;
                                    classTreeNode.Nodes.Add(methodTreeNode);
                                    hasMethods = true;
                                }
                            }
                        }

                        if (hasMethods)
                        {
                            namespaceTreeNode.Nodes.Add(classTreeNode);
                            hasClasses = true;
                        }

                    }

                    if (hasClasses)
                    {
                        this.itemTreeView.Nodes.Add(namespaceTreeNode);
                    }
                }
            }
        }

        private void ClearExceptionList()
        {
            this.exceptionList.Items.Clear();
        }

        private void PopulateExceptionList(MethodBase method)
        {
            this.exceptionList.Items.Clear();

            var exceptions = method.GetAllExceptions();
            foreach (var exception in new List<Type>(exceptions).OrderBy(o=>o.FullName))
            {
                exceptionList.Items.Add(exception.FullName);
            }
        }

        private void itemTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var method = e.Node.Tag as MethodBase;
            if (method != null)
            {
                PopulateExceptionList(method);
            }
            else
            {
                ClearExceptionList();
            }
        }
    }

    public static class MethodInfoExtensions
    {
        public static string GetFriendlyName(this MethodInfo methodInfo)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendFormat("{0}(", methodInfo.Name);

            List<String> parameterDescriptions = new List<string>();
            foreach (ParameterInfo parameter in methodInfo.GetParameters())
            {
                parameterDescriptions.Add(string.Format("{0} {1}", parameter.GetType().Name, parameter.Name));
            }

            sb.Append(string.Join(", ", parameterDescriptions));

            sb.Append(")");

            return sb.ToString();
        }

        public static MethodBase GetMethodBase( this MethodInfo method)
        {
            try
            {
                return MethodBase.GetMethodFromHandle(method.MethodHandle);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
    }
}
