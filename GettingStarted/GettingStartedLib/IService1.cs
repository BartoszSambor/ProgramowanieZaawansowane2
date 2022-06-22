using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace GettingStartedLib
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        List<Book> GetBooks();
        [OperationContract]
        bool InsertBook(Book book);
        [OperationContract]
        bool UpdateBook(List<Book> book);
        [OperationContract]
        List<Book> GetBorrowedBooks(string login);
        [OperationContract]
        bool BorrowBook(string login, Book book);
        [OperationContract]
        List<BorrowedElem> GetBorrowedBooksAll();
        [OperationContract]
        bool ReturnBook(string login, Book book);
        [OperationContract]
        bool DeleteBook(Book book);
        [OperationContract]
        List<BorrowedElem> GetBorrowedBooksWithTime(string login);
        [OperationContract]
        List<BorrowedHistory> GetHistory(string login);
        [OperationContract]
        List<Notification> GetNotifications(string login);
        [OperationContract]
        List<Notification> GetNotificationsAll();
        [OperationContract]
        bool ClearNotifications(string login);
        [OperationContract]
        List<Subscription> GetSubscriptionsAll();
        [OperationContract]
        List<string> GetSubscriptions(string login);
        [OperationContract]
        bool SubscribeAndClear(string login, List<string> types);


    }
}