﻿/* Copyright (c) Mark Seemann 2019 all rights reserved
 * Permission is hereby granted to share this code for educational purposes
 * only, under the condition that this header remains intact. */
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ploeh.Samples.BookingApi.UnitTests
{
    public class MaîtreDTests
    {
        [Theory]
        [InlineData( 4, 10)]
        [InlineData(10, 10)]
        [InlineData(20, 20)]
        [InlineData( 1, 22)]
        public void CanAcceptReturnsReservationInHappyPathScenario(
            int quantity,
            int capacity)
        {
            var reservation = new Reservation
            {
                Date = new DateTime(2018, 8, 30),
                Quantity = quantity
            };
            var sut = new MaîtreD(capacity);

            var actual = sut.CanAccept(new Reservation[0], reservation);

            Assert.True(actual);
        }

        [Fact]
        public void CanAcceptOnInsufficientCapacity()
        {
            var reservation = new Reservation
            {
                Date = new DateTime(2018, 8, 30),
                Quantity = 4
            };
            var sut = new MaîtreD(capacity: 10);

            var actual = sut.CanAccept(
                new[] { new Reservation { Quantity = 7 } },
                reservation);

            Assert.False(actual);
        }
    }
}
