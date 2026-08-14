# NuGet release process

Packages are validated and published to NuGet.org by `.github/workflows/publish-nuget.yml`. Authentication uses NuGet Trusted Publishing and GitHub OIDC, so no long-lived NuGet API key is stored in the repository.

## One-time NuGet.org setup

1. Sign in to [NuGet.org](https://www.nuget.org/).
2. Open the user menu, select **Trusted Publishing**, and create a GitHub policy.
3. Select the individual or organization that will own the package.
4. Enter the following policy values:

   | Field | Value |
   | --- | --- |
   | Repository owner | `KAJOOSH` |
   | Repository | `PasarGuard.ApiClient.NET` |
   | Workflow file | `publish-nuget.yml` |
   | Environment | `nuget` |

The workflow filename must not include `.github/workflows/`.

## One-time GitHub setup

1. Open **Settings > Environments** in the GitHub repository.
2. Create an environment named `nuget`.
3. Add deployment protection rules or required reviewers if desired.
4. Open **Settings > Secrets and variables > Actions**.
5. Add a repository secret named `NUGET_USER` containing the NuGet.org username that owns the Trusted Publishing policy. Use the profile name, not the email address.

No NuGet API key is required. The workflow exchanges GitHub's OIDC identity for a temporary NuGet API key immediately before publication.

## Publish a release

Every push to `master` starts the publication workflow. The workflow reads `PackageVersion` from `src/PasarGuard.ApiClient/PasarGuard.ApiClient.csproj` and checks the exact package version in the NuGet.org V3 registry.

If the version already exists, publication is skipped successfully. If it does not exist, the workflow builds the complete solution, runs formatting verification and all tests, creates `.nupkg` and `.snupkg` files, uploads them as a GitHub Actions artifact, and publishes both packages to NuGet.org.

To publish a new release, update `VersionPrefix` in the package project and push the commit to `master`:

```xml
<VersionPrefix>5.2.2</VersionPrefix>
```

The workflow can also be started from **Actions > Publish NuGet > Run workflow** to repeat the same version check for the selected branch.

NuGet package versions are immutable. Publish a new version instead of attempting to replace an existing package.

## Fallback API key

If Trusted Publishing is not available for the NuGet.org account, create a scoped API key under **API Keys** with permission to push new packages and package versions. Restrict its package pattern to `PasarGuard.ApiClient`, store it as a GitHub Actions secret, and update the login and publish steps to use that secret. Trusted Publishing is preferred because it avoids a long-lived credential.
