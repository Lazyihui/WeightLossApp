using System;

namespace GJ {

    public class LoginSystemEvents {
        public Action OnStartHandle;
        public void OnAdd() => OnStartHandle.Invoke();

        public LoginSystemEvents() { }
    }
}