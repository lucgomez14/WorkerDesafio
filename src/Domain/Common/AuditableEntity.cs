﻿using System;

namespace worker_application.Domain.Common;

public record struct AuditableEntity(DateTime Created, string CreatedBy, DateTime? LastModified, string LastModifiedBy) { }