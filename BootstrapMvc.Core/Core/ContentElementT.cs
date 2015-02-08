﻿using System;

namespace BootstrapMvc.Core
{
    public abstract class ContentElement<T> : Element where T : DisposableContent
    {
        public ContentElement(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public virtual T BeginContent()
        {
            WriteSelfStart(this.Context.Writer);
            var retVal = CreateContentContext();
            retVal.Disposing += OnContentContextDispose;
            return retVal;
        }

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            WriteSelfStart(writer);
            WriteSelfEnd(writer);
        }

        protected void OnContentContextDispose(object sender, EventArgs args)
        {
            WriteSelfEnd(this.Context.Writer);
        }

        protected abstract T CreateContentContext();

        protected abstract void WriteSelfStart(System.IO.TextWriter writer);

        protected abstract void WriteSelfEnd(System.IO.TextWriter writer);
    }
}
