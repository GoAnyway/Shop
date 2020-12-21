using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Models.MainModels
{
    public class BaseModel : INotifyPropertyChanged
    {
        public Guid Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool Equals(BaseModel other) => Id.Equals(other.Id);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((BaseModel) obj);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(BaseModel left, BaseModel right) => Equals(left, right);

        public static bool operator !=(BaseModel left, BaseModel right) => !Equals(left, right);

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}