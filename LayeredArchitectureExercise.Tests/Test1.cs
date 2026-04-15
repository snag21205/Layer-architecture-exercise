using System;
using System.Collections.Generic;
using BLL;
using DAL;
using DTO;

namespace LayeredArchitectureExercise.Tests
{
    [TestClass]
    public sealed class BorrowServiceTests
    {
        [TestMethod]
        public void BorrowBook_WhenMemberIdIsInvalid_ThrowsArgumentException()
        {
            var fakeRepo = new FakeBorrowRecordRepository();
            var service = new BorrowService(fakeRepo);

            Assert.ThrowsException<ArgumentException>(() => service.BorrowBook(0, 1));
        }

        [TestMethod]
        public void BorrowBook_WhenBookIdIsInvalid_ThrowsArgumentException()
        {
            var fakeRepo = new FakeBorrowRecordRepository();
            var service = new BorrowService(fakeRepo);

            Assert.ThrowsException<ArgumentException>(() => service.BorrowBook(1, 0));
        }

        [TestMethod]
        public void BorrowBook_WhenInputsAreValid_CallsRepositoryOnceWithCorrectValues()
        {
            var fakeRepo = new FakeBorrowRecordRepository();
            var service = new BorrowService(fakeRepo);

            service.BorrowBook(5, 10);

            Assert.AreEqual(1, fakeRepo.BorrowBookCallCount);
            Assert.AreEqual(5, fakeRepo.LastMemberId);
            Assert.AreEqual(10, fakeRepo.LastBookId);
        }

        [TestMethod]
        public void GetAll_ReturnsRepositoryData()
        {
            var expected = new List<BorrowRecordView>
            {
                new BorrowRecordView
                {
                    MemberName = "Alice",
                    BookTitle = "Clean Code",
                    BorrowDate = new DateTime(2026, 4, 15),
                    ReturnDate = null
                }
            };

            var fakeRepo = new FakeBorrowRecordRepository
            {
                ItemsToReturn = expected
            };
            var service = new BorrowService(fakeRepo);

            var actual = service.GetAll();

            Assert.AreSame(expected, actual);
        }

        private sealed class FakeBorrowRecordRepository : IBorrowRecordRepository
        {
            public int BorrowBookCallCount { get; private set; }
            public int LastMemberId { get; private set; }
            public int LastBookId { get; private set; }
            public List<BorrowRecordView> ItemsToReturn { get; set; } = new List<BorrowRecordView>();

            public void BorrowBook(int memberId, int bookId)
            {
                BorrowBookCallCount++;
                LastMemberId = memberId;
                LastBookId = bookId;
            }

            public List<BorrowRecordView> GetAll()
            {
                return ItemsToReturn;
            }
        }
    }
}
