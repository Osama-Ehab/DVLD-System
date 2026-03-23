using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public static class SqlCommandExtensions
    {
        /// <summary>
        /// Adds a parameter with explicit type and size, handling null values.
        /// </summary>
        public static void AddParameterWithTypeAndSize(this SqlCommand command, string parameterName, SqlDbType dbType, int size, object value)
        {
            var parameter = command.Parameters.Add(parameterName, dbType, size);
            parameter.Value = value ?? DBNull.Value;
        }

        /// <summary>
        /// Adds a parameter with explicit type and size, returning the SqlCommand for chaining.
        /// </summary>
        public static SqlCommand AddParameterWithTypeAndSizeChain(this SqlCommand command, string parameterName, SqlDbType dbType, int size, object value)
        {
            var parameter = command.Parameters.Add(parameterName, dbType, size);
            parameter.Value = value ?? DBNull.Value;
            return command;
        }

        /// <summary>
        /// Adds a parameter using AddWithValue but makes it null-safe.
        /// </summary>
        public static SqlCommand AddParameterWithValueSafe(this SqlCommand command, string parameterName, object value)
        {
            command.Parameters.AddWithValue(parameterName, value ?? DBNull.Value);
            return command;
        }

        /// <summary>
        /// Adds a parameter by inferring SqlDbType from the CLR type of the value.
        /// </summary>
        public static void AddParameterInferred(this SqlCommand command, string parameterName, object value)
        {
            var sqlType = InferSqlDbType(value);
            var parameter = command.Parameters.Add(parameterName, sqlType);
            parameter.Value = value ?? DBNull.Value;
        }

        /// <summary>
        /// Adds a parameter by inferring SqlDbType from the CLR type of the value (with size for text fields).
        /// </summary>
        public static void AddParameterInferredWithSize(this SqlCommand command, string parameterName, object value, int size)
        {
            var sqlType = InferSqlDbType(value);
            var parameter = command.Parameters.Add(parameterName, sqlType, size);
            parameter.Value = value ?? DBNull.Value;
        }

        /// <summary>
        /// Infers SqlDbType based on common CLR types.
        /// </summary>
        private static SqlDbType InferSqlDbType(object value)
        {
            if (value == null) return SqlDbType.Variant;

            Type type = value.GetType();

            if (type == typeof(string)) return SqlDbType.NVarChar;
            if (type == typeof(int)) return SqlDbType.Int;
            if (type == typeof(short)) return SqlDbType.SmallInt;
            if (type == typeof(long)) return SqlDbType.BigInt;
            if (type == typeof(bool)) return SqlDbType.Bit;
            if (type == typeof(DateTime)) return SqlDbType.DateTime;
            if (type == typeof(decimal)) return SqlDbType.Decimal;
            if (type == typeof(double)) return SqlDbType.Float;
            if (type == typeof(float)) return SqlDbType.Real;
            if (type == typeof(byte[])) return SqlDbType.VarBinary;
            if (type == typeof(byte)) return SqlDbType.TinyInt;
            if (type == typeof(Guid)) return SqlDbType.UniqueIdentifier;

            return SqlDbType.Variant;
        }
    }
}

