using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfowareSoft.Blazor.MaterialDesign.Components.Base
{
    public abstract class BaseComponent: ComponentBase, IDisposable
    {
        #region Disposable
        protected bool Disposed { get; private set; }

        public virtual void Dispose()
        {
            Disposed = true;
        }
        #endregion

        #region QueueRenderAfterCall
        private Queue<Func<Task>> _afterRenderFinishedQuene = new Queue<Func<Task>>();
        protected void WhenRenderFinished(Func<Task> action)
        {
            _afterRenderFinishedQuene.Enqueue(action);
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (_afterRenderFinishedQuene.Any())
            {
                var actions = _afterRenderFinishedQuene.ToArray();
                _afterRenderFinishedQuene.Clear();

                foreach (var action in actions)
                {
                    if (Disposed) return;
                    await action();
                }
            }
        }
        #endregion

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        protected async Task<T> JsInvokeAsync<T>(string code, params object[] args)
        {
            try
            {
                return await JSRuntime.InvokeAsync<T>(code, args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Parameter] public RenderFragment ChildContent { get; set; }

        #region Hack to fix https://github.com/aspnet/AspNetCore/issues/11159
        public static object CreateDotNetObjectRefSyncObj = new object();

        protected DotNetObjectReference<T> CreateDotNetObjectRef<T>(T value) where T : class
        {
            lock (CreateDotNetObjectRefSyncObj)
            {
                return DotNetObjectReference.Create(value);
            }
        }

        protected void DisposeDotNetObjectRef<T>(DotNetObjectReference<T> value) where T : class
        {
            if (value != null)
            {
                lock (CreateDotNetObjectRefSyncObj)
                {
                    value.Dispose();
                }
            }
        }

        #endregion

    }
}
