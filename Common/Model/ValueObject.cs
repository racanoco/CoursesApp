namespace Common.Model
{
    /// <summary>
    /// Patrón ValueObject
    /// </summary>
    public abstract class ValueObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<object> GetAtomicValues();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueObjectOne"></param>
        /// <param name="valueObjectTwo"></param>
        /// <returns></returns>
        public static bool operator ==(ValueObject valueObjectOne, ValueObject valueObjectTwo)
        {
            return valueObjectOne?.Equals(valueObjectTwo) ?? false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueObjectOne"></param>
        /// <param name="valueObjectTwo"></param>
        /// <returns></returns>
        public static bool operator !=(ValueObject valueObjectOne, ValueObject valueObjectTwo)
        {
            return !(valueObjectOne?.Equals(valueObjectTwo) ?? false);
        }       

        /// <summary>
        /// Sobrescribimos el método Equals para un comportamiento personalizado.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            ValueObject? other = obj as ValueObject;
            IEnumerator<object> thisValues = GetAtomicValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetAtomicValues().GetEnumerator();

            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if(ReferenceEquals(thisValues.Current, null) != ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }

                if(thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }

            return !thisValues.MoveNext() && !otherValues.MoveNext();
            
        }
    }
}
