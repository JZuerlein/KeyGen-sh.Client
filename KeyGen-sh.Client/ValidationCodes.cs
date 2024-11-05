using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGen_sh.Client
{
    public enum ValidationCodes
    {
        VALID,                      // The validated license resource or license key is valid.
        SUSPENDED,                  // The validated license has been suspended.
        EXPIRED,                    // The validated license is expired.
        OVERDUE,                    // The validated license is overdue for check-in.
        NO_MACHINE,                 // Not activated. The validated license does not meet its node-locked policy's requirement of exactly 1 associated machine.
        NO_MACHINES,                // Not activated. The validated license does not meet its floating policy's requirement of at least 1 associated machine.
        TOO_MANY_MACHINES,          // The validated license has exceeded its policy's machine limit.
        TOO_MANY_CORES,             // The validated license has exceeded its policy's machine core limit.
        TOO_MANY_PROCESSES,         // The validated license has exceeded its policy's machine process limit.
        FINGERPRINT_SCOPE_REQUIRED, // The validated license requires a fingerprint scope to be provided during validation.
        FINGERPRINT_SCOPE_MISMATCH, // Not activated. None or not enough of the validated license's machine relationships match the provided machine fingerprint scope.
        FINGERPRINT_SCOPE_EMPTY,    // A fingerprint scope was supplied but it has an empty or null value.
        COMPONENTS_SCOPE_REQUIRED,  // The validated license requires a components scope to be provided during validation.
        COMPONENTS_SCOPE_MISMATCH,  // None or not enough of the validated license's machine components match the provided components scope.
        USER_SCOPE_REQUIRED,        // The validated license requires a user scope to be provided during validation.
        USER_SCOPE_MISMATCH,        // The user scope does match a license owner or user, or it does not match the owner of the scoped machine (if scoped to a machine and it has an owner).
        HEARTBEAT_NOT_STARTED,      // The validated machine or fingerprint scope requires a heartbeat but one is not started.
        HEARTBEAT_DEAD,             // The validated machine or fingerprint scope belongs to a dead machine.
        BANNED,                     // The user that owns the validated license has been banned.
        PRODUCT_SCOPE_REQUIRED,     // The validated license requires a product scope to be provided during validation.
        PRODUCT_SCOPE_MISMATCH,     // The validated license's product relationship does not match the provided product scope.
        POLICY_SCOPE_REQUIRED,      // The validated license requires a policy scope to be provided during validation.
        POLICY_SCOPE_MISMATCH,      // The validated license's policy relationship does not match the provided policy scope.
        MACHINE_SCOPE_REQUIRED,     // The validated license requires a machine scope to be provided during validation.
        MACHINE_SCOPE_MISMATCH,     // None of the validated license's machine relationships match the provided machine scope.
        ENTITLEMENTS_MISSING,       // The validated license's entitlement relationship is missing one or more of the entitlement scope assertions.
        ENTITLEMENTS_SCOPE_EMPTY,   // An entitlements scope was supplied but it has an empty value.
        VERSION_SCOPE_REQUIRED,     // The validated license requires a version scope to be provided during validation.
        VERSION_SCOPE_MISMATCH,     // None of the validated license's accessible releases match the provided version scope, i.e. the release does not exist or it is inaccessible.
        CHECKSUM_SCOPE_REQUIRED,    // The validated license requires a checksum scope to be provided during validation.
        CHECKSUM_SCOPE_MISMATCH,    // None of the validated license's accessible artifacts match the provided checksum scope, i.e. a matching artifact does not exist or it is inaccessible.
    }
}
