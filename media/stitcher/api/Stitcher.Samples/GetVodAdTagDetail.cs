﻿/*
 * Copyright 2022 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

// [START videostitcher_get_vod_ad_tag_detail]

using Google.Cloud.Video.Stitcher.V1;

public class GetVodAdTagDetailSample
{
    public VodAdTagDetail GetVodAdTagDetail(
        string projectId, string location, string sessionId, string adTagDetailId)
    {
        // Create the client.
        VideoStitcherServiceClient client = VideoStitcherServiceClient.Create();

        GetVodAdTagDetailRequest request = new GetVodAdTagDetailRequest
        {
            VodAdTagDetailName = VodAdTagDetailName.FromProjectLocationVodSessionVodAdTagDetail(projectId, location, sessionId, adTagDetailId)
        };

        // Call the API.
        VodAdTagDetail vodAdTagDetail = client.GetVodAdTagDetail(request);

        // Return the result.
        return vodAdTagDetail;
    }
}
// [END videostitcher_get_vod_ad_tag_detail]
