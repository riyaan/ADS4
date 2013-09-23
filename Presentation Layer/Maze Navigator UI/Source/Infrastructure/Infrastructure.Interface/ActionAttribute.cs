//----------------------------------------------------------------------------------------
// patterns & practices - Smart Client Software Factory - Guidance Package
//
// This file was generated by this guidance package as part of the solution template
//
//  
//
//
// Latest version of this Guidance Package: http://go.microsoft.com/fwlink/?LinkId=62182
//----------------------------------------------------------------------------------------

using System;

namespace MazeNavigatorUI.Infrastructure.Interface
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ActionAttribute : Attribute
    {
        private string _actionName;

        public ActionAttribute(string actionName)
        {
            _actionName = actionName;
        }

        public string ActionName
        {
            get { return _actionName; }
            set { _actionName = value; }
        }
    }
}
