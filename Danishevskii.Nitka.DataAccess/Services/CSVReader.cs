using System;
using System.Data;
using System.IO;


namespace Danishevskii.Nitka.DataAccess.Services
{
    public class CSVReader : IDataReader
    {
        readonly StreamReader _streamReader;

        readonly Func<string, object>[] _convertTable;
        readonly Func<string, bool>[] _constraintsTable;

        string[] _currentLineValues;
        string _currentLine;



        public CSVReader(StreamReader streamReader, Func<string, bool>[] constraintsTable, Func<string, object>[] convertTable)
        {
            _constraintsTable = constraintsTable;
            _convertTable = convertTable;
            _streamReader = streamReader;

            _currentLine = null;
            _currentLineValues = null;
        }

        // Возвращаем значение, используя одну из функций преобразования и обработку исключения.
        // Это обезопасит нас от прерывания загрузки данных.

        public object GetValue(int i)
        {
            try
            {
                return _convertTable[i](_currentLineValues[i]);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Чтение очередной строки.
        // Используем функции ограничения для того, чтобы еще на этапе чтения понять, что строка
        // вызовет исключения при передаче ее в SqlBulkCopy, поэтому мы пропускаем некорректные строки.

        public bool Read()
        {
            if (_streamReader.EndOfStream) return false;

            _currentLine = _streamReader.ReadLine();

            // В случае, если значения будут содержать символ ";" это работать не будет,
            // и придется использовать более сложный алгоритм разбора.
            _currentLineValues = _currentLine.Split(';');

            var invalidRow = false;
            for (int i = 0; i < _currentLineValues.Length; i++)
            {
                if (!_constraintsTable[i](_currentLineValues[i]))
                {
                    invalidRow = true;
                    break;
                }
            }

            return !invalidRow || Read();
        }
             

        public int FieldCount
        {
            get { return 5; }
        }

        public int Depth => throw new NotImplementedException();

        public bool IsClosed => throw new NotImplementedException();

        public int RecordsAffected => throw new NotImplementedException();

        public object this[string name] => throw new NotImplementedException();

        public object this[int i] => throw new NotImplementedException();

        // Освобождаем ресурсы. Закрываем поток.

        public void Dispose()
        {
            _streamReader.Close();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public DataTable GetSchemaTable()
        {
            throw new NotImplementedException();
        }

        public bool NextResult()
        {
            throw new NotImplementedException();
        }

        public string GetName(int i)
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }

        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public int GetOrdinal(string name)
        {
            throw new NotImplementedException();
        }

        public bool GetBoolean(int i)
        {
            throw new NotImplementedException();
        }

        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }

        public int GetInt32(int i)
        {
            throw new NotImplementedException();
        }

        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }

        public double GetDouble(int i)
        {
            throw new NotImplementedException();
        }

        public string GetString(int i)
        {
            throw new NotImplementedException();
        }

        public decimal GetDecimal(int i)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int i)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public bool IsDBNull(int i)
        {
            throw new NotImplementedException();
        }

        // ... множестве нереализованных методов IDataReader, которые здесь не нужны.
    }
}
