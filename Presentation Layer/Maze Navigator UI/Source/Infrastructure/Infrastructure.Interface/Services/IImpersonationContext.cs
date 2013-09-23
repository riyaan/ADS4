//----------------------------------------------------------------------------------------
// patterns & practices - Smart Client Software Factory - Guidance Package
//
// This file was generated by this guidance package as part of the solution template
//
// The IImpersonationContext interface is used along with the IImpersonationService
// in order to mantain the state and revert the impersonation process
//
//  
//
//
// Latest version of this Guidance Package: http://go.microsoft.com/fwlink/?LinkId=62182
//----------------------------------------------------------------------------------------

using System;

namespace MazeNavigatorUI.Infrastructure.Interface.Services
{
    public interface IImpersonationContext : IDisposable
    {
        object State { get; set; }
        void Undo();
    }
}
