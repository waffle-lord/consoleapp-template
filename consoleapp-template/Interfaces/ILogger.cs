namespace $safeprojectname$.Interfaces
{
    internal interface ILogger
    {
        #region Debug Wrappers
        // with Type
        public void Debug(Type type, string message);

        public void Debug(Type type, string messageTemplate, params object[] propertyValues);

        public void Debug(Type type, Exception ex, string messageTemplate);

        public void Debug(Type type, Exception ex, string messageTemplate, params object[] propertyValues);

        // with T
        public void Debug<T>(string message);

        public void Debug<T>(string messageTemplate, params object[] propertyValues);

        public void Debug<T>(Exception ex, string messageTemplate);

        public void Debug<T>(Exception ex, string messageTemplate, params object[] propertyValues);
        #endregion

        #region Info Wrappers
        // with Type
        public void Info(Type type, string message);

        public void Info(Type type, string messageTemplate, params object[] propertyValues);

        public void Info(Type type, Exception ex, string messageTemplate);

        public void Info(Type type, Exception ex, string messageTemplate, params object[] propertyValues);

        // with T
        public void Info<T>(string message);

        public void Info<T>(string messageTemplate, params object[] propertyValues);

        public void Info<T>(Exception ex, string messageTemplate);

        public void Info<T>(Exception ex, string messageTemplate, params object[] propertyValues);
        #endregion

        #region Warning Wrappers
        // with type
        public void Warn(Type type, string message);

        public void Warn(Type type, string messageTemplate, params object[] propertyValues);

        public void Warn(Type type, Exception ex, string messageTemplate);

        public void Warn(Type type, Exception ex, string messageTemplate, params object[] propertyValues);

        // with T
        public void Warn<T>(string message);

        public void Warn<T>(string messageTemplate, params object[] propertyValues);

        public void Warn<T>(Exception ex, string messageTemplate);

        public void Warn<T>(Exception ex, string messageTemplate, params object[] propertyValues);
        #endregion

        #region Error Wrappers
        // with type
        public void Error(Type type, string message);

        public void Error(Type type, string messageTemplate, params object[] propertyValues);

        public void Error(Type type, Exception ex, string messageTemplate);

        public void Error(Type type, Exception ex, string messageTemplate, params object[] propertyValues);

        // with T
        public void Error<T>(string message);

        public void Error<T>(string messageTemplate, params object[] propertyValues);

        public void Error<T>(Exception ex, string messageTemplate);

        public void Error<T>(Exception ex, string messageTemplate, params object[] propertyValues);
        #endregion

        #region Fatal Wrappers
        // with type
        public void Fatal(Type type, string message);

        public void Fatal(Type type, string messageTemplate, params object[] propertyValues);

        public void Fatal(Type type, Exception ex, string messageTemplate);

        public void Fatal(Type type, Exception ex, string messageTemplate, params object[] propertyValues);

        // with T
        public void Fatal<T>(string message);

        public void Fatal<T>(string messageTemplate, params object[] propertyValues);

        public void Fatal<T>(Exception ex, string messageTemplate);

        public void Fatal<T>(Exception ex, string messageTemplate, params object[] propertyValues);
        #endregion
    }
}
