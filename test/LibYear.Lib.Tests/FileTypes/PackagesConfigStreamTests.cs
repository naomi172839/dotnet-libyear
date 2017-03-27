﻿using System;
using System.Collections.Generic;
using System.Linq;
using LibYear.Lib.FileTypes;
using Xunit;

namespace LibYear.Lib.Tests.FileTypes
{
    public class PackagesConfigStreamTests
    {
        private static System.IO.Stream LoadStreamFromFile(string fileName)
        {
            return System.IO.File.OpenRead(fileName);
        }

        [Fact]
        public void CanLoadPackagesConfigStream()
        {
            //arrange
            const string filename = "FileTypes\\packages.config";
            using (var stream = LoadStreamFromFile(filename))
            {
                //act
                var packagesConfigStream = new PackagesConfigStream(stream);

                //assert
                Assert.Equal("test1", packagesConfigStream.Packages.First().Key);
                Assert.Equal("test2", packagesConfigStream.Packages.Skip(1).First().Key);
                Assert.Equal("test3", packagesConfigStream.Packages.Skip(2).First().Key);
            }
        }

        [Fact]
        public void AttemptingToReadFileNameWillThrowNotSupportedException()
        {
            //arrange
            const string filename = "FileTypes\\packages.config";
            using (var stream = LoadStreamFromFile(filename))
            {
                //act
                var packagesConfigStream = new PackagesConfigStream(stream);

                //Assert
                Assert.Throws<NotSupportedException>(() => packagesConfigStream.FileName);
            }
        }

        [Fact]
        public void AttemptingToUpdateWillThrowNotSupportedException()
        {
            //arrange
            const string filename = "FileTypes\\packages.config";
            using (var stream = LoadStreamFromFile(filename))
            {
                //act
                var packagesConfigStream = new PackagesConfigStream(stream);

                //assert
                Assert.Throws<NotSupportedException>(() => packagesConfigStream.Update(new List<Result>()));
            }
        }
    }
}