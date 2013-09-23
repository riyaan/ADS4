//----------------------------------------------------------------------------------------
// patterns & practices - Smart Client Software Factory - Guidance Package
//
// The BaseTranslator class is a base helper implementation of an IEntityTranslator
// 
//  
//
//
// Latest version of this Guidance Package: http://go.microsoft.com/fwlink/?LinkId=62182
//----------------------------------------------------------------------------------------

using System;
using MazeNavigatorUI.Infrastructure.Interface.Services;

namespace MazeNavigatorUI.Infrastructure.Library.EntityTranslators
{
    public abstract class BaseTranslator : IEntityTranslator
    {
        public abstract bool CanTranslate(Type targetType, Type sourceType);

        public bool CanTranslate<TTarget, TSource>()
        {
            return CanTranslate(typeof(TTarget), typeof(TSource));
        }

        public TTarget Translate<TTarget>(IEntityTranslatorService service, object source)
        {
            return (TTarget)Translate(service, typeof(TTarget), source);
        }

        public abstract object Translate(IEntityTranslatorService service, Type targetType, object source);
    }
}
