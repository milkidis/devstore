using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStore.API.ModelPresenter
{
    public partial class JsonMessage<T>
    {
        public JsonMessage()
        {
            this.BusinessObject = (T)Activator.CreateInstance(typeof(T));
        }

        public string Success { get; set; }
        public string Err { get; set; }
        public T BusinessObject { get; set; }

    }
    public partial class JsonMessage
    {
        public string Success { get; set; }
        public string Err { get; set; }
    }
}