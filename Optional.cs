using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot_for_parameter
{
    public class Optional<T>
    {
        private readonly T value;
        private readonly bool hasValue;

        private Optional(T value, bool hasValue)
        {
            this.value = value;
            this.hasValue = hasValue;
        }

        public static Optional<T> Of(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            return new Optional<T>(value, true);
        }

        public static Optional<T> OfNullable(T value)
        {
            return new Optional<T>(value, value != null);
        }

        public static Optional<T> Empty()
        {
            return new Optional<T>(default(T), false);
        }

        public T OrElse(T defaultValue)
        {
            return hasValue ? value : defaultValue;
        }

        public T GetValue()
        {
            if (!hasValue) throw new InvalidOperationException("No value present");
            return value;
        }

        public bool IsPresent => hasValue;

        public void IfPresent(Action<T> action)
        {
            if (hasValue) action(value);
        }

        public override string ToString()
        {
            return hasValue ? $"Optional[{value}]" : "Optional.Empty";
        }
    }
}
