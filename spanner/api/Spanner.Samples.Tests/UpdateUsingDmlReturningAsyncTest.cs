﻿// Copyright 2023 Google Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Google.Cloud.Spanner.Data;
using System.Threading.Tasks;
using Xunit;

[Collection(nameof(SpannerFixture))]
public class UpdateUsingDmlReturningAsyncTest
{
    private readonly SpannerFixture _spannerFixture;

    public UpdateUsingDmlReturningAsyncTest(SpannerFixture spannerFixture)
    {
        _spannerFixture = spannerFixture;
    }

    [Fact]
    public async Task TestUpdateUsingDmlReturningAsync()
    {
        await _spannerFixture.RunWithTemporaryDatabaseAsync(async databaseId =>
        {
            await CreateTableAndInsertData(databaseId);
            FillMarketingBudgetsAsync(300000, 300000, databaseId);

            var sample = new UpdateUsingDmlReturningAsyncSample();
            var updatedMarketingBudgets = await sample.UpdateUsingDmlReturningAsync(_spannerFixture.ProjectId, _spannerFixture.InstanceId, databaseId);

            Assert.Single(updatedMarketingBudgets);
            Assert.Equal(600000, updatedMarketingBudgets[0]);
        });
    }

    private async Task CreateTableAndInsertData(string databaseId)
    {
        await _spannerFixture.CreateSingersAndAlbumsTableAsync(_spannerFixture.ProjectId, _spannerFixture.InstanceId, databaseId);
        var insertDataAsyncSample = new InsertDataAsyncSample();
        await insertDataAsyncSample.InsertDataAsync(_spannerFixture.ProjectId, _spannerFixture.InstanceId, databaseId);
    }

    private async void FillMarketingBudgetsAsync(int firstAlbumBudget, int secondAlbumBudget, string databaseId)
    {
        var connection = new SpannerConnection($"Data Source=projects/{_spannerFixture.ProjectId}/instances/{_spannerFixture.InstanceId}/databases/{databaseId}");

        for (int i = 1; i <= 2; ++i)
        {
            var spannerParameterCollection = new SpannerParameterCollection
            {
                { "SingerId", SpannerDbType.Int64, i },
                { "AlbumId", SpannerDbType.Int64, i },
                { "MarketingBudget", SpannerDbType.Int64, i == 1 ? firstAlbumBudget : secondAlbumBudget },
            };

            using var cmd = connection.CreateUpdateCommand("Albums", spannerParameterCollection);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
