using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz.");
            RuleFor(x => x.ReceiverMail).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi  yapın.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla değer girişi yapmayın.");

            RuleFor(x => x.SenderMail).Must(IsValidEmail).WithMessage("Geçerli bir email adresi giriniz.");
            RuleFor(x => x.ReceiverMail).Must(IsValidEmail).WithMessage("Geçerli bir email adresi giriniz.");

        }

        private bool IsValidEmail(string arg)
        {
            if (new EmailAddressAttribute().IsValid(arg))
                return true;
            else
                return false;
        }
    }
}
