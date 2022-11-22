package com.krm3d.childSiblings.services.impl;

import com.krm3d.childSiblings.dtos.CreatedChildSiblingsDto;
import com.krm3d.childSiblings.dtos.DeletedChildSiblingsDto;
import com.krm3d.childSiblings.dtos.UpdatedChildSiblingsDto;
import com.krm3d.childSiblings.entities.ChildSiblings;
import com.krm3d.childSiblings.repositories.ChildSiblingsRepository;
import com.krm3d.childSiblings.rules.ChildSiblingsBusinessRules;
import com.krm3d.childSiblings.services.ChildSiblingsService;
import org.modelmapper.ModelMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Arrays;
import java.util.List;

@Service
public class ChildSiblingServiceImpl implements ChildSiblingsService {
    private ChildSiblingsRepository childSiblingsRepository;
    private ChildSiblingsBusinessRules childSiblingsBusinessRules;
    private ModelMapper mapper;
    @Autowired
    public ChildSiblingServiceImpl(ChildSiblingsRepository childSiblingsRepository, ChildSiblingsBusinessRules childSiblingsBusinessRules, ModelMapper mapper) {
        this.childSiblingsRepository = childSiblingsRepository;
        this.childSiblingsBusinessRules = childSiblingsBusinessRules;
        this.mapper = mapper;
    }

    @Override
    public CreatedChildSiblingsDto add(CreatedChildSiblingsDto createdChildSiblingsDto) {
        var mappedChildrenSiblings = this.mapper.map(createdChildSiblingsDto, ChildSiblings.class);
        this.childSiblingsRepository.save(mappedChildrenSiblings);
        var result = this.mapper.map(mappedChildrenSiblings, CreatedChildSiblingsDto.class);
        return result;
    }

    @Override
    public List<CreatedChildSiblingsDto> addAll(List<CreatedChildSiblingsDto> createdChildSiblingsDto)throws Exception {
        var ch = Arrays.asList(mapper.map(createdChildSiblingsDto, ChildSiblings[].class));
        this.childSiblingsRepository.saveAll(ch);
        return createdChildSiblingsDto;
    }

    @Override
    public List<CreatedChildSiblingsDto> addAll2(List<CreatedChildSiblingsDto> createdChildSiblingsDto) throws Exception {
        for (var createdChildSiblings: createdChildSiblingsDto) {
            var  childSiblings= mapper.map(createdChildSiblings, ChildSiblings.class);
            this.childSiblingsBusinessRules.ToUpper(childSiblings);
            this.childSiblingsBusinessRules.Trim(childSiblings);
            this.childSiblingsRepository.save(childSiblings);
        }
        return  createdChildSiblingsDto;
    }

    @Override
    public UpdatedChildSiblingsDto update(UpdatedChildSiblingsDto updatedChildSiblingsDto) {
        var mappedChildrenSiblings = this.mapper.map(updatedChildSiblingsDto, ChildSiblings.class);
        this.childSiblingsRepository.save(mappedChildrenSiblings);
        return updatedChildSiblingsDto;
    }

    @Override
    public DeletedChildSiblingsDto delete(DeletedChildSiblingsDto deletedChildSiblingsDto) {
        var mappedId = this.childSiblingsRepository.findById(deletedChildSiblingsDto.getId()).get();
        this.childSiblingsRepository.delete(mappedId);
        return deletedChildSiblingsDto;
    }
}