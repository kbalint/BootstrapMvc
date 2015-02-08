﻿using System;
using System.Collections.Generic;

namespace BootstrapMvc.Core
{
    public abstract class AnyContentElement : ContentElement<AnyContent>
    {
        private WritableBlock content;

        protected string endTag = null;

        public AnyContentElement(IBootstrapContext context)
            : base(context)
        {
            // nothing
        }

        public void AddContent(object value)
        {
            var newContent = new SimpleBlock(Context).Value(value);
            if (content == null)
            {
                content = newContent;
            }
            else
            {
                content.Append(newContent);
            }
        }

        protected abstract string WriteSelfStartTag(System.IO.TextWriter writer);

        protected override AnyContent CreateContentContext()
        {
            return new AnyContent(Context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            endTag = WriteSelfStartTag(writer);
            if (content != null)
            {
                content.WriteTo(writer);
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write(endTag);
        }
    }
}
