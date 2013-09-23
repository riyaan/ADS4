//----------------------------------------------------------------------------------------
// patterns & practices - Smart Client Software Factory - Guidance Package
//
// The EntityTranslatorService class is a service that provides a registry of
// translators and translation services between two classes. The user must implement
// the translators and register them with the service.
// 
//  
//
//
// Latest version of this Guidance Package: http://go.microsoft.com/fwlink/?LinkId=62182
//----------------------------------------------------------------------------------------

using System;

namespace MazeNavigatorUI.Infrastructure.Interface.Services
{
    public interface IEntityTranslatorService
    {
        bool CanTranslate(Type targetType, Type sourceType);
        bool CanTranslate<TTarget, TSource>();
        object Translate(Type targetType, object source);
        TTarget Translate<TTarget>(object source);
        void RegisterEntityTranslator(IEntityTranslator translator);
        void RemoveEntityTranslator(IEntityTranslator translator);
    }
}
